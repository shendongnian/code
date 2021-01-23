    FolderSelectDDL uc = new FolderSelectDDL();
    public ImportCreateExcel()
    {
        //FolderSelectDDL.OnUserControlButtonClicked += new FolderSelectDDL.ButtonClickedEventHandler(btnSaveToPath_Click);
        uc.OnUserControlButtonClicked += new FolderSelectDDL.ButtonClickedEventHandler(btnSaveToPath_Click);
        InitializeComponent();
    }
    private void btnSaveToPath_Click(object sender, EventArgs e)
    {
        //FolderSelectDDL uc = new FolderSelectDDL(); //a new instance
        MessageBox.Show(uc.FolderPath);
    }
