    public partial class ViewerWindow : Window
        {
            XpsDocument doc;
            string fileName;
    
            public ViewerWindow()
            {
                InitializeComponent();
    
                // get file name from command line
                string[] args = System.Environment.GetCommandLineArgs();
                fileName = args[1];
    
                // size window
                this.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
                this.Height = System.Windows.SystemParameters.PrimaryScreenHeight;
                this.Width = ((System.Windows.SystemParameters.PrimaryScreenHeight * 8.5) / 11);
    
                // Open File and Create XpsDocument
                if (!File.Exists(fileName) || fileName == null || fileName == "") 
                {
                    System.Windows.MessageBox.Show("File Not Found!");
                    this.Close();
                }
                else if (!fileName.EndsWith(".xps") && !fileName.EndsWith(".oxps"))
                {
                    System.Windows.MessageBox.Show("File not in XPS format");
                    this.Close();
                }
                else 
                {
                    try
                    {
                        doc = new XpsDocument(fileName, System.IO.FileAccess.Read);
                    }
                    catch (UnauthorizedAccessException)
                    {
                        System.Windows.MessageBox.Show("Unable to open file - check user permission settings and make sure that the file is not open in another program.");
                        this.Close();
                    }
                }
    
                // Display XpsDocument in Viewer
                Viewer.Document = doc.GetFixedDocumentSequence();
            }
        }
