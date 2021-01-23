    public void PopulateItemsList()
    {
        BoxAndFileList.Items.Clear();
        ScanIdBox.Text = string.Empty;
        for (int i = 0; i < BoxNumberRepository._boxAndFileList.Count; i++)
        {
            string item = BoxNumberRepository._boxAndFileList.Item[i];
            if (item.Length == 8)
            {
                BoxAndFileList.Items.Insert(0, item);
            }
            else
            {
                BoxAndFileList.Items.Insert(1, item);
            }
        }
    }
