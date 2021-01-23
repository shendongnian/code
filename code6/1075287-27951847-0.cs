     protected void Page_Load(object sender, EventArgs e)
    {
        
            List<TreeNode> root = new List<TreeNode>();
            for(int i = 0; i < 5; i++)
            {
                root.Add(new TreeNode("Parent Node " + i, i.ToString()));
            }
            foreach (TreeNode tn in root)
            {
                tn.ChildNodes.Add(new TreeNode("First Child", "first"));
                tn.ChildNodes.Add(new TreeNode("Second Child", "second"));                              
                tvDevices.Nodes.Add(tn);
            }
            tvDevices.CollapseAll(); //Collapse all nodes
            RestoreTreeViewState(tvDevices.Nodes, (List<string>)Session["tvState"] ?? new List<string>()); //Restore previously expanded nodes
    }
    private void SaveTreeViewState(TreeNodeCollection treeNodes, List<string> expandedList)
    {
        foreach (TreeNode treeNode in treeNodes)
        {
            if (treeNode.ChildNodes.Count > 0)
            {
                if (treeNode.Expanded.HasValue && treeNode.Expanded == true)
                {
                    expandedList.Add(treeNode.Value);
                }
                SaveTreeViewState(treeNode.ChildNodes, expandedList);
            }   
        }            
    }
    private void RestoreTreeViewState(TreeNodeCollection treeNodes, List<string> expandedList)
    {            
        foreach (TreeNode treeNode in treeNodes)
        {
            
             if(expandedList.Count == 0)
                return;
            if (expandedList.Contains(treeNode.Value))
            {
                if (treeNode.ChildNodes.Count > 0)
                {                         
                    treeNode.Expand();
                    RestoreTreeViewState(treeNode.ChildNodes, expandedList);
                }                 
            }                
        }
    }
    protected void TvDevices_OnTreeNodeExpandedCollapsed(object sender, EventArgs e)
    {                     
        List<string> expandedList = new List<string>();  
        SaveTreeViewState(tvDevices.Nodes, expandedList);
        Session["tvDevicesState"] = expandedList;
    }   
