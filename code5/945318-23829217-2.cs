        private static void TraverseTreeNode(TreeNodeCollection nodes, int parentNumber)
        {
            var childNumber = 1;
            foreach (TreeNode node in nodes)
            {
                node.Value = string.Format("{0}{1}", parentNumber, childNumber ).Substring(0,node.Depth+1);
                TraverseTreeNode(node.ChildNodes, parentNumber);
                childNumber++;
                if (node.Depth == 0) { parentNumber++; }
            }
        }
