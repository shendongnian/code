    public static class TreeViewExtensions
    {
        public static void PopulateNodes(this TreeView treeView, IEnumerable<ITreeNodeViewModel> viewNodes)
        {
            treeView.BeginUpdate();
            try
            {
                treeView.Nodes.PopulateNodes(viewNodes);
            }
            finally
            {
                treeView.EndUpdate();
            }
        }
        public static void PopulateNodes(this TreeNodeCollection nodes, IEnumerable<ITreeNodeViewModel> viewNodes)
        {
            nodes.Clear();
            if (viewNodes == null)
                return;
            foreach (var viewNode in viewNodes)
            {
                var name = viewNode.Name;
                var text = viewNode.Text;
                if (string.IsNullOrEmpty(text))
                    text = name;
                var node = new TreeNode { Name = name, Text = text, Tag = viewNode.Tag };
                nodes.Add(node);
                PopulateNodes(node.Nodes, viewNode.Children);
                node.Expand();
            }
        }
    }
    public static class XObjectExtensions
    {
        public static string TextValue(this XContainer node)
        {
            if (node == null)
                return null;
            //return string.Concat(node.Nodes().OfType<XText>().Select(tx => tx.Value));  c# 4.0
            return node.Nodes().OfType<XText>().Select(tx => tx.Value).Aggregate(new StringBuilder(), (sb, s) => sb.Append(s)).ToString();
        }
        public static IEnumerable<XElement> Elements(this IEnumerable<XElement> elements, XName name)
        {
            return elements.SelectMany(el => el.Elements(name));
        }
    }
