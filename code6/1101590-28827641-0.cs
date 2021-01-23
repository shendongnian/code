    private void searchAll(DirectoryItem root, string name)
    {
        for (int a = 0; a < root.Items.Count; a++)
        {
            if (name == root.Items[a].Name)
            {
                //
            }
            searchAll(root.Items[a], name);
        }
    }
