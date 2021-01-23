    for (int i = 0; i < FolderToSearch.Items.Count; ++i)
    {
        COMObject item = FolderToSearch.Items[i];
        try
        {
            // work
        }
        finally
        {
            System.Runtime.InteropServices.ReleaseComObject(item);
        }
    }
