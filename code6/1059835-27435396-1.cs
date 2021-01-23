Program.cs
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace PassThroughPrinterTest
    {
        static class Program
        {
            [STAThread]
            static void Main()
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new TrayApplicationContext());
            }
        }
    }
TrayApplicationContext.cs
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace PassThroughPrinterTest
    {
        class TrayApplicationContext : ApplicationContext
        {
            private NotifyIcon trayIcon;
            private PrintListener listener;
            private PrintHandler handler;
    
            public TrayApplicationContext()
            {
                this.trayIcon = new NotifyIcon()
                {
                    Text = "Card Formatter",
                    Icon = Properties.Resources.AppIcon,
                    ContextMenu = new ContextMenu()
                    {
                        MenuItems =
                        {
                            new MenuItem("Print Options...", miPrintOptions_Click),
                            new MenuItem("Exit", miExit_Click)
                        }
                    },
                    Visible = true
                };
    
                this.handler = new PrintHandler();
    
                this.listener = new PrintListener(9101);
                this.listener.PrintDataReceived += this.handler.HandlePrintData;
            }
    
            private void miPrintOptions_Click(object sender, EventArgs args)
            {
                // TODO: add configuration and options to avoid having to hard code
                // the printer name in PrintHandler.cs
                MessageBox.Show("Options");
            }
    
            private void miExit_Click(object sender, EventArgs args)
            {
                Application.Exit();
            }
    
            protected override void Dispose(bool disposing)
            {
                base.Dispose(disposing);
    
                if (disposing)
                {
                    trayIcon.Dispose();
                }
            }
        }
    }
PrintHandler.cs
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Drawing.Printing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Xml.Linq;
    
    namespace PassThroughPrinterTest
    {
        partial class PrintHandler : Form
        {
            public PrintHandler()
            {
                InitializeComponent();
            }
    
            public void HandlePrintData(object sender, PrintDataReceivedEventArgs args)
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new EventHandler<PrintDataReceivedEventArgs>(HandlePrintData), sender, args);
                    return;
                }
    
                this.Show();
    
                var sXml = Encoding.UTF8.GetString(args.PrintData);
                this.PrintCard(XDocument.Parse(sXml));
    
                this.Hide();
            }
    
            private void PrintCard(XDocument xDocument)
            {
                var nameElement = xDocument.Root.Element("name");
                var lastName = nameElement.Attribute("last").Value;
                var firstName = nameElement.Attribute("first").Value;
                var mrn = xDocument.Root.Element("mrn").Value;
    
                var printDoc = new PrintDocument()
                {
                    PrinterSettings = new PrinterSettings()
                    {
                        PrinterName = "Adobe PDF"
                    },
                    DocumentName = "Patient ID Card"
                };
                var cardPaperSize = new PaperSize("Card", 337, 213) { RawKind = (int)PaperKind.Custom };
                printDoc.DefaultPageSettings.PaperSize = cardPaperSize;
                printDoc.PrinterSettings.DefaultPageSettings.PaperSize = cardPaperSize;
                printDoc.PrintPage += (s, e) =>
                {
                    var gfx = e.Graphics;
    
                    // print the text information
                    var fArial12 = new Font("Arial", 12);
                    gfx.DrawString(lastName, fArial12, Brushes.Black, new RectangleF(25, 25, 200, 75));
                    gfx.DrawString(firstName, fArial12, Brushes.Black, new RectangleF(25, 100, 200, 75));
    
                    // add a code39 barcode using a barcode font
                    // http://www.idautomation.com/free-barcode-products/code39-font/
                    // var fCode39 = new Font("IDAutomationHC39M", 12);
                    // gfx.DrawString("(" + mrn + ")", fArial12, Brushes.Black, new RectangleF(25, 200, 200, 75));
    
                    // or by using a barcode library
                    // https://barcoderender.codeplex.com/
                    // var barcode = BarcodeDrawFactory.Code128WithChecksum.Draw(mrn, 20, 2);
                    // gfx.DrawImage(barcode, 50, 200);
    
                    e.HasMorePages = false;
                };
                printDoc.Print();
            }
        }
    }
PrintListener.cs
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Diagnostics.Contracts;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading;
    
    namespace PassThroughPrinterTest
    {
        sealed class PrintListener : IDisposable
        {
            private TcpListener listener;
    
            public event EventHandler<PrintDataReceivedEventArgs> PrintDataReceived;
    
            public PrintListener(int port)
            {
                this.listener = new TcpListener(IPAddress.Loopback, port);
                this.listener.Start();
    
                this.listener.BeginAcceptTcpClient(listener_AcceptClient, null);
            }
    
            public void Dispose()
            {
                this.listener.Stop();
            }
    
            private void listener_AcceptClient(IAsyncResult iar)
            {
                TcpClient client = null;
                bool isStopped = false;
                try
                {
                    client = this.listener.EndAcceptTcpClient(iar);
                }
                catch (ObjectDisposedException)
                {
                    // this will occur in graceful shutdown
                    isStopped = true;
                    return;
                }
                finally
                {
                    if (!isStopped)
                    {
                        this.listener.BeginAcceptTcpClient(listener_AcceptClient, null);
                    }
                }
                Debug.Assert(client != null);
    
                try
                {
                    byte[] printData;
                    using (var clientStream = client.GetStream())
                    using (var buffer = new MemoryStream())
                    {
                        clientStream.CopyTo(buffer);
    
                        printData = buffer.ToArray();
                    }
    
                    OnPrintDataReceived(printData);
                }
                catch
                {
                    // TODO: add logging and error handling for network issues or processing issues
                    throw;
                }
                finally
                {
                    client.Close();
                }
            }
    
            private void OnPrintDataReceived(byte[] printData)
            {
                var handler = PrintDataReceived;
                if (handler != null)
                {
                    handler(this, new PrintDataReceivedEventArgs(printData));
                }
            }
        }
    }
TrayApplicationContext.cs
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace PassThroughPrinterTest
    {
        class TrayApplicationContext : ApplicationContext
        {
            private NotifyIcon trayIcon;
            private PrintListener listener;
            private PrintHandler handler;
    
            public TrayApplicationContext()
            {
                this.trayIcon = new NotifyIcon()
                {
                    Text = "Card Formatter",
                    Icon = Properties.Resources.AppIcon,
                    ContextMenu = new ContextMenu()
                    {
                        MenuItems =
                        {
                            new MenuItem("Print Options...", miPrintOptions_Click),
                            new MenuItem("Exit", miExit_Click)
                        }
                    },
                    Visible = true
                };
    
                this.handler = new PrintHandler();
    
                this.listener = new PrintListener(9101);
                this.listener.PrintDataReceived += this.handler.HandlePrintData;
            }
    
            private void miPrintOptions_Click(object sender, EventArgs args)
            {
                // TODO: add configuration and options to avoid having to hard code
                // the printer name in PrintHandler.cs
                MessageBox.Show("Options");
            }
    
            private void miExit_Click(object sender, EventArgs args)
            {
                Application.Exit();
            }
    
            protected override void Dispose(bool disposing)
            {
                base.Dispose(disposing);
    
                if (disposing)
                {
                    listener.Dispose();
                    trayIcon.Dispose();
                }
            }
        }
    }
PrintDataReceivedEventArgs.cs
    using System;
    
    namespace PassThroughPrinterTest
    {
        class PrintDataReceivedEventArgs : EventArgs
        {
            public byte[] PrintData { get; set; }
    
            public PrintDataReceivedEventArgs(byte[] data)
            {
                if (data == null)
                    throw new ArgumentNullException("data");
    
                this.PrintData = data;
            }
        }
    }
