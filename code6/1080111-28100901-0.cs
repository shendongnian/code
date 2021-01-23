     public partial class MainWindow : Window
        {
          public FileInfo myFileInfo;
          //...
    public MainWindow(FileInfo theInfo)
    {
    InitializeComponent();
    myFileInfo = theInfo;
    }
    
          public MainWindow()
          {
              InitializeComponent();
              LabelFileName.Content = "File Name: " + this.myFileInfo.Name.ToString(); // Null exception
          //...
          }
        }
