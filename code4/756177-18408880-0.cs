    public void PopulateTreeView()
    {
         var items = new List<string>(_boxNumberRepository.GetAllItems());
        foreach (var boxNumber in items)
            BoxAndFileList.SelectedNode.Nodes.Add(boxNumber);
        ScanIdBox.Text = string.Empty;
    }
