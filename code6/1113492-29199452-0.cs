    private void PopulateTreeView(Option option, TreeNode existingNode = null)
    {
        if (option != null)
        {
            TreeNode newNode = new TreeNode();
            newNode.Text = option.Title;
            newNode.Tag = option;
                
            if (existingNode == null)
            {
                pages.Nodes.Add(newNode);
            }
            else
            {
                existingNode.Nodes.Add(newNode);
            }
            foreach (GotoOption gotoOption in option.GotoOptions)
            {
                Option newOption = Options.FirstOrDefault(i => i.Id == gotoOption.GotoId);
                PopulateTreeView(newOption, newNode);
            }
        }
    }
