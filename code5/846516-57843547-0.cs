        private void SelectNode(TreeNodeCollection nodes, string v)
        {
            Queue<TreeNode> queue = new Queue<TreeNode>();
            foreach(TreeNode node in nodes)
                queue.Enqueue(node);
            while(queue.Any())
            {
                TreeNode node = queue.Dequeue();
                if(node.Value == v)
                {
                    node.Select();
                    return;
                }
                foreach (TreeNode child in node.ChildNodes)
                    queue.Enqueue(child);
            }
        }
