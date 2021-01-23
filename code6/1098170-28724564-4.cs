    public delegate string GetString<T>(T input); // No Func<T, TResult> in c# 2.0
    public static class XmlTreeViewHelper
    {
        public static void AddOrMergeNodes(TreeNodeCollection treeNodeCollection, XmlNodeList xmlNodeList, GetString<XmlNode> getNodeName, GetString<XmlNode> getNodeText, Predicate<XmlNode> filter)
        {
            Dictionary<string, List<TreeNode>> dict = ToNodeDictionary(treeNodeCollection);
            int index = 0;
            foreach (XmlNode inXmlNode in xmlNodeList)
            {
                AddOrMergeNode(treeNodeCollection, inXmlNode, ref index, getNodeName, getNodeText, filter, dict);
            }
            foreach (List<TreeNode> list in dict.Values)
                foreach (TreeNode leftover in list)
                {
                    treeNodeCollection.Remove(leftover);
                }
        }
        static bool IsNodeAtIndex(TreeNodeCollection nodes, TreeNode node, int index)
        {
            // Avoid n-squared nodes.IndexOf(node).
            if (index < 0 || index >= nodes.Count)
                return false;
            return nodes[index] == node;
        }
        static void AddOrMergeNode(TreeNodeCollection treeNodeCollection, XmlNode inXmlNode, ref int index, GetString<XmlNode> getNodeName, GetString<XmlNode> getNodeText, Predicate<XmlNode> filter, Dictionary<string, List<TreeNode>> dict)
        {
            if (filter != null && !filter(inXmlNode))
                return;
            string treeName = getNodeName(inXmlNode);
            string treeText = (getNodeText == null ? treeName : getNodeText(inXmlNode));
            bool added = false;
            TreeNode treeNode;
            if (!dict.TryRemoveFirst(treeName, out treeNode))
            {
                treeNode = new TreeNode();
                treeNode.Name = treeName;
                treeNode.Text = treeText;
                added = true;
                treeNodeCollection.Insert(index, treeNode);
            }
            else
            {
                if (!IsNodeAtIndex(treeNodeCollection, treeNode, index))
                {
                    treeNodeCollection.Remove(treeNode);
                    treeNodeCollection.Insert(index, treeNode);
                }
            }
            index++;
            if (treeNode.Text != treeText)
                treeNode.Text = treeText;
            if (inXmlNode.HasChildNodes)
                AddOrMergeNodes(treeNode.Nodes, inXmlNode.ChildNodes, getNodeName, getNodeText, filter);
            else
                treeNode.Nodes.Clear();
            if (added)
                treeNode.ExpandAll();
        }
        /// <summary>
        /// Returns a dictionary of tree nodes by node name.
        /// </summary>
        /// <param name="nodes"></param>
        /// <returns></returns>
        static Dictionary<string, List<TreeNode>> ToNodeDictionary(TreeNodeCollection nodes)
        {
    #if false
            // c# 3.0
            return nodes.Cast<TreeNode>().Aggregate(new Dictionary<string, List<TreeNode>>(), (d, n) => { d.Add(n.Name, n); return d; });
    #else
            Dictionary<string, List<TreeNode>> dict = new Dictionary<string, List<TreeNode>>();
            foreach (TreeNode node in nodes)
            {
                List<TreeNode> list;
                if (!dict.TryGetValue(node.Name, out list))
                    dict[node.Name] = list = new List<TreeNode>();
                list.Add(node);
            }
            return dict;
    #endif
        }
    }
