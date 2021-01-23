    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Process p = new Process();
            try
            {
                p.StartInfo.FileName = AppDomain.CurrentDomain.BaseDirectory + "\\scan.cmd";
                p.Start();
                p.WaitForExit();
            }
            catch (Exception exception)
            {
            }
            // Read the file and display it line by line.
            string logFile = AppDomain.CurrentDomain.BaseDirectory + "log.txt";
            string line;
            System.IO.StreamReader file = new System.IO.StreamReader(logFile);
            while ((line = file.ReadLine()) != null)
            {
                itemBeiingScanned_Label.Content = line;
            }
            file.Close();
        }
    }
