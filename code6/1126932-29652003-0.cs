    string rowFilter = string.Empty;
    foreach (TreeNode node in treeView1.Nodes)
    {
        // In case you add more root nodes to filter on, you'll want to check children nodes under each root node
        if (node.Text == "AreaCode")
        {
            // Iterate through the root node's children nodes and build your filter based on them being checked or unchecked
            foreach (TreeNode childNode in node.Nodes)
            {
                if (childNode.Checked)
                {
                    if (rowFilter.Length > 0)
                    {
                        rowFilter += " OR ";
                    }
                    rowFilter += "[AreaCode] = " + childNode.Text;
                }
            }
        }
    }
    
    // Apply rowFilter to DataView.RowFilter
