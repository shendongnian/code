        static class Class1
        {
            public static int CountByText(this TreeView view, string text)
            {
                int count = 0;
                
               //logic to iterate through nodes and do count
                foreach (TreeNode node in view.Nodes)
                {
                    nodeList.Add(node);
                    Get(node);
                }
                foreach (TreeNode node in nodeList)
                {
                    if (node.Text == text)
                    {
                        count++;
                    }
                }
               nodeList.Clear();
               return count;
            }
    
            static List<TreeNode> nodeList = new List<TreeNode>();
            static void Get(TreeNode node)
            {
                foreach (TreeNode n in node.Nodes)
                {
                    nodeList.Add(n);
                    Get(n);
                }
            }
         }
