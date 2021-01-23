    Items items = FolderToSearch.Items;
    try
    {
        for (int i = 0; i < items.Count; ++i)
        {
            COMObject item = items[i];
            try
            {
                // work
            }
            finally
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(item);
            }
        }
    }
    finally
    {
        System.Runtime.InteropServices.Marshal.ReleaseComObject(items);
    }
