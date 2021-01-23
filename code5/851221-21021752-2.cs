            FolderBrowserDialog folderBrowserDlg = new FolderBrowserDialog();
            DialogResult dlgResult = folderBrowserDlg.ShowDialog();
            if (dlgResult.Equals(DialogResult.OK))
            {
                foreach (string file in System.IO.Directory.GetFiles(folderBrowserDlg.SelectedPath, "*.png")) //.png, bmp, etc.
                {
                    Image image = new Bitmap(file);
                    imageList1.Images.Add(image);                 
                }
            }
            this.listView1.View = View.LargeIcon;
            this.imageList1.ImageSize = new Size(32, 32);
            this.listView1.LargeImageList = this.imageList1;
            for (int j = 0; j < this.imageList1.Images.Count; j++)
            {
                ListViewItem item = new ListViewItem();
                item.ImageIndex = j;
                this.listView1.Items.Add(item);
            }
