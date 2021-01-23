           {
            TreeNode treeNode = new TreeNode("Windows");
            TreeNode node2 = new TreeNode("C#");
            TreeNode node3 = new TreeNode("VB.NET");
            node2.Nodes.Add("whatever");
            treeNode.Nodes.Add(node2);
            treeNode.Nodes.Add(node3);
            treeView1.Nodes.Add(treeNode);
            treeNode = new TreeNode("Linux");
            treeView1.Nodes.Add(treeNode);
           }
