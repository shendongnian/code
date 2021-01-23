        private void AddToListBtn_Click(object sender, EventArgs e)
        {
             string itemText = HideFolderAddress.Tag.ToString();
             if (!FolderList.Items.ContainsKey(itemText))
             {
                   ListViewItem itemList = FolderList.Items.Add(itemText , itemText , -1);
                   itemList.SubItems.Add(HideFolderAddress.Text);
             }
         }
