    public partial class FolderSelectDDL : UserControl
    {
      public delegate void ButtonClickedEventHandler(object sender, EventArgs e);
      public static event ButtonClickedEventHandler OnUserControlButtonClicked;
      private string folderPath;
      public string FolderPath
      {
        get { return folderPath; }
        set { folderPath = value; }
      }
      public FolderSelectDDL()
      {
        InitializeComponent();
      }
      private void btnSaveToPath_Click(object sender, EventArgs e)
      {
        string path;
        if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
        {
            path = folderBrowserDialog1.SelectedPath;
            if (OnUserControlButtonClicked != null)
                OnUserControlButtonClicked(this, e);
            folderPath = path;
            //Fire event here
            if(OnUserControlButtonClicked != null) OnUserControlButtonClicked(this, EventArgs.Empty);
         }        
      }
    }
