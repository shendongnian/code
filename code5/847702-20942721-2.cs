    using System;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace WinformsWb
    {
        public partial class MainForm : Form
        {
            public MainForm()
            {
                InitializeComponent();
            }
    
            const string HTML_DATA =
                "<form target='_blank' action='http://requestb.in/yc89ojyc' method='post' enctype='multipart/form-data'>" +
                "<input type='hidden' name='arg' value='val'>" +
                "<button type='submit' name='go'  value='submit'>Submit</button>" +
                "</form>";
    
            // this code depends on SHDocVw.dll COM interop assembly,
            // generate SHDocVw.dll: "tlbimp.exe ieframe.dll",
            // and add as a reference to the project
    
            private async void MainForm_Load(object sender, EventArgs e)
            {
                // make sure the ActiveX has been created
                if ((this.webBrowser.Document == null && this.webBrowser.ActiveXInstance == null))
                    throw new ApplicationException("webBrowser");
    
                // handle NewWindow
                var activex = (SHDocVw.WebBrowser_V1)this.webBrowser.ActiveXInstance;
                activex.NewWindow += delegate(string URL, int Flags, string TargetFrameName, ref object PostData, string Headers, ref bool Processed)
                {
                    Processed = true;
    
                    object flags = Flags;
                    object targetFrame = Type.Missing;
                    object postData = PostData != null ? PostData : Type.Missing;
                    object headers = !String.IsNullOrEmpty(Headers) ? Headers.ToString() : Type.Missing;
    
                    SynchronizationContext.Current.Post(delegate
                    {
                        activex.Navigate(URL, ref flags, ref targetFrame, ref postData, ref headers);
                    }, null);
                };
    
                // navigate to a stream
                using (var stream = new MemoryStream())
                using (var writer = new StreamWriter(stream))
                {
                    writer.Write(HTML_DATA);
                    writer.Flush();
                    stream.Position = 0;
    
                    // naviage and await DocumentCompleted
                    var tcs = new TaskCompletionSource<bool>();
                    WebBrowserDocumentCompletedEventHandler handler = (s, arg) =>
                        tcs.TrySetResult(true);
                    this.webBrowser.DocumentCompleted += handler;
                    this.webBrowser.DocumentStream = stream;
                    await tcs.Task;
                    this.webBrowser.DocumentCompleted -= handler;
                }
    
                // click the button
                var button = this.webBrowser.Document.GetElementById("go");
                button.InvokeMember("click");
            }
        }
    }
