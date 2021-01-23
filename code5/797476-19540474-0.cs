    public bool SelectDirectory(out String directoryName)
    {
        System.Windows.Forms.FolderBrowserDialog dlg = new System.Windows.Forms.FolderBrowserDialog();
        directoryName = String.Empty;
        dlg.SelectedPath = String.Empty;
        if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        {
            directoryName = dlg.SelectedPath;
            return true;
       }
       else
        {
            return false;
        }
    }
