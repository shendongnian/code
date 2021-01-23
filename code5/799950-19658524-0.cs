    public static class TreeViewExtension
    {
        public static void LoadFromDataTable(this TreeView tv, DataTable dt)
        {
            var parentNodes = dt.AsEnumerable()
                                .GroupBy(row => (string)row[0])
                                .ToDictionary(g => g.Key, value => value.Select(x => (string)x[1]));
            Stack<KeyValuePair<TreeNode, IEnumerable<string>>> lookIn = new Stack<KeyValuePair<TreeNode, IEnumerable<string>>>();
            HashSet<string> removedKeys = new HashSet<string>();
            foreach (var node in parentNodes)
            {
                if (removedKeys.Contains(node.Key)) continue;
                TreeNode tNode = new TreeNode(node.Key);
                lookIn.Push(new KeyValuePair<TreeNode, IEnumerable<string>>(tNode, node.Value));
                while (lookIn.Count > 0)
                {
                    var nodes = lookIn.Pop();
                    foreach (var n in nodes.Value)
                    {
                        IEnumerable<string> children;
                        TreeNode childNode = new TreeNode(n);
                        nodes.Key.Nodes.Add(childNode);
                        if (parentNodes.TryGetValue(n, out children))
                        {
                            lookIn.Push(new KeyValuePair<TreeNode, IEnumerable<string>>(childNode, children));
                            removedKeys.Add(n);
                        }
                    }
                }
                tv.Nodes.Add(tNode);
            }
        }
    }
