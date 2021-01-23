    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            maps_webbrowser.DocumentText = File.ReadAllText(@"GPSmap.html");
        }
        private void maps_webbrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            Debug.WriteLine(maps_webbrowser.DocumentText.ToString());
            maps_webbrowser.Document.InvokeScript("initialize");
        }
    }
