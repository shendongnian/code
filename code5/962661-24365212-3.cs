        private void PopulateTreeView_Load(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Level");
            table.Columns.Add("Data");
            table.Rows.Add(1, "a");
            table.Rows.Add(2, "b");
            table.Rows.Add(2, "c");
            table.Rows.Add(1, "d");
            table.Rows.Add(2, "e");
            table.Rows.Add(2, "f");
            table.Rows.Add(3, "g");
            table.Rows.Add(4, "z");
            table.Rows.Add(5, "x");
            table.Rows.Add(2, "h");
            table.Rows.Add(3, "i");
            table.Rows.Add(1, "j");
            table.Rows.Add(2, "k"); 
            TreeNode lastNode = new TreeNode();    
       
            for (int i = 0; i < table.Rows.Count; i++)
            {
                TreeNode newNode = new TreeNode((string)table.Rows[i]["Data"]);                
                
                if (i == 0)
                    treeView.Nodes.Add(newNode);
                else
                {
                    int currentLevel = Convert.ToInt32(table.Rows[i]["Level"]);
                    int lastLevel = Convert.ToInt32(table.Rows[i-1]["Level"]);
                    
                    if (currentLevel < lastLevel)
                    {
                        if (currentLevel == 1)
                            treeView.Nodes.Add(newNode);
                        else
                        {
                            TreeNode currentNode = lastNode.Parent;
                            for (int j = 0; j < lastLevel - currentLevel; j++)
                                currentNode = currentNode.Parent;
                            currentNode.Nodes.Add(newNode);
                        }
                    }
                    else if (currentLevel == lastLevel)
                    {
                         lastNode.Parent.Nodes.Add(newNode);                   
                    }
                    else
                    {
                        lastNode.Nodes.Add(newNode);
                    }
                }
               
                lastNode = newNode;
            }           
        }
    
