    public static class XmlNodeHelper
    {
        public static IEnumerable<XmlNode> ChildNodes(IEnumerable<XmlNode> xmlNodeList)
        {
            if (xmlNodeList == null)
                yield break;
            foreach (XmlNode node in xmlNodeList)
                foreach (XmlNode childNode in node.ChildNodes)
                    yield return childNode;
        }
        public static IEnumerable<TNode> OfType<TNode>(XmlNodeList xmlNodeList) where TNode : XmlNode
        {
            // Convert XmlNodeList which implements non-generic IEnumerable to IEnumerable<XmlNode> by downcasting the nodes
            if (xmlNodeList == null)
                yield break;
            foreach (XmlNode xmlNode in xmlNodeList)
                if (xmlNode is TNode)
                    yield return (TNode)xmlNode;
        }
    }
    public static class XmlTreeViewHelper
    {
        public static void AddOrMergeNodes(TreeNodeCollection treeNodeCollection, IEnumerable<XmlNode> xmlNodeList, GetString<XmlNode> getNodeName, GetString<XmlNode> getNodeText, Predicate<XmlNode> filter)
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
            if (!DictionaryExtensions.TryRemoveFirst(dict, treeName, out treeNode))
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
                AddOrMergeNodes(treeNode.Nodes, XmlNodeHelper.OfType<XmlNode>(inXmlNode.ChildNodes), getNodeName, getNodeText, filter);
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
            Dictionary<string, List<TreeNode>> dict = new Dictionary<string, List<TreeNode>>();
            foreach (TreeNode node in nodes)
                DictionaryExtensions.Add(dict, node.Name, node);
            return dict;
        }
    }
