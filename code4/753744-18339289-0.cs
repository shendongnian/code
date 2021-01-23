    private void NewProject()
    {
        var saveFolderDlg = new FolderBrowserDialog();
        DialogResult dlgResult = saveFolderDlg.ShowDialog();
        if (dlgResult == System.Windows.Forms.DialogResult.OK)
        {
            saveFolderDlg.RootFolder = Environment.SpecialFolder.Desktop;
            saveFolderDlg.ShowNewFolderButton = true;
            string projectPath = saveFolderDlg.SelectedPath;
            string prjFileName = System.IO.Path.GetFileName(projectPath);
            string newPath = System.IO.Path.Combine(projectPath, prjFileName);
            if (!System.IO.File.Exists(newPath + ".rnd"))
            {
                CreateNewProejct(projectPath);//works fine
            }
            else
            {
                string msgBoxTxt = "Project already exists, Override?";
                MessageBoxButton button = MessageBoxButton.YesNoCancel;
                string caption = "New porject";
                MessageBoxImage icon = MessageBoxImage.Warning;
                MessageBoxResult result = MessageBox.Show(msgBoxTxt, caption, button, icon);
                switch (result)
                {
                    case MessageBoxResult.No:
                        NewProject();
                        break;
                    case MessageBoxResult.Cancel:
                        break;
                    case MessageBoxResult.Yes:
                        CreateNewProejct(projectPath);
                        break;
                }
            }
        }
    }
