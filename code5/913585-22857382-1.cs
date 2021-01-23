        void Add2ndLevelNode(TreeNodeCollection nodes, Item current, IList<Item> items)
        {
            var children = items.Where(x => x.Key == current.Value && x.ID != current.ID);
            bool doIt = false;
            foreach (var child in children)
            {
                if (items.Any(x => x.Key == child.Value))
                    doIt = true;
            }
            if (doIt)
            {
                TreeNode treenode = nodes.Add(current.Value.ToString(), current.Value.ToString());
                foreach (var child in children)
                {
                    AddNode(treenode.Nodes, child, items);
                }
            }
        }
