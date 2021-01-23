    private void HideItBtn_Click(object sender, EventArgs e)
    {
        using (StreamWriter hide = new StreamWriter(HideNameTxt.Text + ".txt"))
            for (int i = 0; i < FolderList.Items.Count; i++)
                for (int j = 1; j < FolderList.Items[i].SubItems.Count; j++)
                {
                    ListViewSubItem cur = FolderList.Items[i].SubItems[j];
                    hide.WriteLine("attrib \"" + cur.Text + "\"" 
                        + Environment.NewLine);
                }
    }
