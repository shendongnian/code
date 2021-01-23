    private void addImages_Click(object sender, RoutedEventArgs e)
    { 
        ImageList.Items.Clear();
        RefreshList();
        FileInfo Images;
        string[] filenames = null;
        System.Windows.Forms.FolderBrowserDialog folderDlg = new System.Windows.Forms.FolderBrowserDialog();
        folderDlg.ShowNewFolderButton = true;
        System.Windows.Forms.DialogResult result = folderDlg.ShowDialog();
    
        if (result == System.Windows.Forms.DialogResult.OK)
        {
            filenames = System.IO.Directory.GetFiles(folderDlg.SelectedPath);
    
            foreach (string image in filenames)
            {
                Images = new FileInfo(image);
    
                if(new string[]{".png", ".jpg", ".gif", ".jpeg", ".bmp", ".tif"}.Contains(Images.Extension.ToLower()))
                {
                    ImageList.Items.Add(new LoadImages(new BitmapImage(new Uri(image))));
                }
            }
        }
        RefreshList();
    }
    private void RefreshList()
    {
        // Force visual refresh of control
        ImageList.Refresh();
    }
