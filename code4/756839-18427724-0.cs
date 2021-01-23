    using System;
    using System.Diagnostics;
    using System.Threading;
    using System.Windows.Forms;
    
    namespace WinformsIE
    {
        public partial class Form1 : Form
        {
             public Form1()
            {
                SetBrowserFeatureControl();
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs ev)
            {
                var ie = (SHDocVw.InternetExplorer)Activator.CreateInstance(Type.GetTypeFromProgID("InternetExplorer.Application"));
                ie.Visible = true;
                Debug.Print("Main thread: {0}", Thread.CurrentThread.ManagedThreadId);
                ie.DocumentComplete += (object browser, ref object URL) =>
                {
                    string url = URL.ToString();
                    Debug.Print("Event thread: {0}", Thread.CurrentThread.ManagedThreadId);
                    this.Invoke(new Action(() =>
                    {
                        Debug.Print("Action thread: {0}", Thread.CurrentThread.ManagedThreadId);
                        var message = String.Format("Page loaded: {0}", url);
                        MessageBox.Show(message);
                    }));
                };
                ie.Navigate("http://www.example.com");
            }
    
        }
    }
