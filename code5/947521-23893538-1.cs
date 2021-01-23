        private void AddToListBtn_Click(object sender, EventArgs e)
        {
             string itemTag = HideFolderAddress.Tag.ToString();
             if (!FolderList.Items.ContainsKey(itemTag ))
             {
                   ListViewItem itemList = FolderList.Items.Add(itemTag , itemTag , -1);
                   itemList.SubItems.Add(HideFolderAddress.Text);
             }
         }
