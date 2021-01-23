    for (int j = 1; j < FolderList.Items[i].SubItems.Count; j++)
    {
        ListViewItem.ListViewSubItem cur = FolderList.Items[i].SubItems[j];
        strArray[i] = cur.Text;
        hide.WriteLine("attrib \"" + strArray[i] + "\" +s +h");
        i++;
    }
