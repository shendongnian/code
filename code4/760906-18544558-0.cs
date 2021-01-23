    public partial class Form1 : Form
    {
        BackgroundWorker fileParser;
        public Form1()
        {
            InitializeComponent();
            fileParser = new BackgroundWorker();
            fileParser.WorkerReportsProgress = true;
            fileParser.DoWork += new DoWorkEventHandler(fileParser_DoWork);
            fileParser.ProgressChanged += new ProgressChangedEventHandler(fileParser_ProgressChanged);
            // Emulating the FolderBrowserDialog results here
            List<String> fileNames = new List<String> { "File 1", "File 2", "File 3", "File 4", "File 5" };
            fileParser.RunWorkerAsync(fileNames);
        }
        void fileParser_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // Update progress bar here
            tbOutput.Text += e.ProgressPercentage.ToString() + "% | ";
        }
        void fileParser_DoWork(object sender, DoWorkEventArgs e)
        {
            List<String> fileNames = e.Argument as List<String>;
            for (int i = 0; i < fileNames.Count; i++)
            {
                // Do intense work here
                Thread.Sleep(2000);
                this.Invoke(new Action(() => { tbOutput.Text += fileNames[i] + ": "; }));
                float completePercent = ((float)(i + 1) / (float)fileNames.Count) * 100;
                
                // Send event to update progress bar here
                fileParser.ReportProgress(Convert.ToInt32(completePercent));
            }
        }        
    }
