    private void SortFileList()
    {
        int length = listBoxOpenFiles.Items.Count;
        string[] keys = new string[length];
        ListBoxItem[] items = new ListBoxItem[length];
            
        for(int i = 0; i < length; ++i)
        {
            keys[i] = ((listBoxOpenFiles.Items[i] as ListBoxItem).Tag as MyClass).FileName;
            items[i] = listBoxOpenFiles.Items[i] as ListBoxItem;
        }
        Array.Sort(keys, items);
        listBoxOpenFiles.Items.Clear();
        for (int i = 0; i < length; ++i)
        {
            listBoxOpenFiles.Items.Add(items[i]);
        }
    }
