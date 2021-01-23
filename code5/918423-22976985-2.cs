    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Program.MyPeriodicUploader.SetUploadHandler(UploadHandler);
            Program.MyPeriodicUploader.InputFile = "yourFileToUpload.txt";
            Program.MyPeriodicUploader.TargetUrl = "http://youraddress.com";
            Program.MyPeriodicUploader.StartTimer();
        }
        private void UploadHandler(string fileName, string targetUrl)
        {
            if (fileName == null) throw new ArgumentNullException("fileName");
            // Upload your file
            using (var webClient = new WebClient())
            {
                webClient.UploadFileAsync(new Uri(targetUrl), fileName);
            }
        }
    }
