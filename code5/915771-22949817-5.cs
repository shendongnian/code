    public MainWindow()
    {
        Messenger.Default.Register<SelectFolderMessage>(this, SelectFolderHandler);
    }
    private void SelectFolderHandler(SelectFolderMessage msg)
    {
        using (System.Windows.Forms.FolderBrowserDialog folderdialg = new System.Windows.Forms.FolderBrowserDialog())
        {
            folderdialg.ShowNewFolderButton = false;
            folderdialg.RootFolder = Environment.SpecialFolder.MyComputer;
            folderdialg.Description = "Load Images for the Game";
            folderdialg.ShowDialog();
            if (folderdialg.SelectedPath != null)
            {
                msg.CallBack(folderdialg.SelectedPath);
            }
        }
    }
