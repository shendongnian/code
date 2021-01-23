        Thread thdSyncRead = new Thread(new ThreadStart(openfolder));
        thdSyncRead.SetApartmentState(ApartmentState.STA);
        thdSyncRead.Start();
    }
    public void openfolder()
    {
        FolderBrowserDialog fbd = new FolderBrowserDialog();
        DialogResult result = fbd.ShowDialog();
        string selectedfolder = fbd.SelectedPath;
        string[] files = Directory.GetFiles(fbd.SelectedPath);
        System.Windows.Forms.MessageBox.Show("Files found: " + files.Length.ToString(), "Message");
    }
