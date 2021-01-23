    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace WindowsForms_22340190
    {
        public partial class MainForm : Form
        {
            public MainForm()
            {
                InitializeComponent();
    
                var cts = new CancellationTokenSource();
    
                this.Load += async (s, e) =>
                {
                    // start the background thread in 1s
                    await Task.Delay(1000);
    
                    Form popup = null;
    
                    var task = Task.Run(() => 
                    {
                        // background thread
                        this.Invoke(new Action(() => 
                        {
                            // create a popup on the main UI thread
                            popup = new Popup { Width = 300, Height = 200 };
                            popup.Show(this);
                        }));
    
                        // imitate some work
                        var i = 0;
                        while (true)
                        {
                            Thread.Sleep(1000);
                            cts.Token.ThrowIfCancellationRequested();
    
                            var n = i++;
                            this.BeginInvoke(new Action(() =>
                            {
                                // update the popup UI on the main UI thread
                                popup.Text = "Popup, step #" + n;
                            }));
                        }
                    });
    
                    // wait 2s more and display a modal dialog
                    await Task.Delay(2000);
    
                    var dialog = new ModalDialog { Width = 200, Height = 100 };
    
                    if (popup != null)
                    {
                        popup.Enabled = false;
                        dialog.Load += delegate { 
                            popup.Enabled = true; };
                    }
                    
                    dialog.ShowDialog(this);
                };
    
                this.FormClosing += (s, e) =>
                    cts.Cancel();
            }
        }
    
        public partial class ModalDialog : Form
        {
            public ModalDialog() 
            { 
                this.Text = "Dialog";
                this.Controls.Add(new TextBox { Width = 50, Height = 20 });
            }
        }
    
        public partial class Popup : Form
        {
            public Popup() 
            { 
                this.Text = "Popup";
                this.Controls.Add(new TextBox { Width = 50, Height = 20 });
            }
        }
    }
