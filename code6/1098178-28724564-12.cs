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
            Dictionary<string, List<TreeNode>> dict = new Dictionary<string, List<TreeNode>>();
            foreach (TreeNode node in nodes)
                DictionaryExtensions.Add(dict, node.Name, node);
            return dict;
        }
    }
    public static class DictionaryExtensions
    {
        public static void Add<TKey, TValueList, TValue>(IDictionary<TKey, TValueList> listDictionary, TKey key, TValue value)
            where TValueList : IList<TValue>, new()
        {
            if (listDictionary == null)
                throw new ArgumentNullException();
            TValueList values;
            if (!listDictionary.TryGetValue(key, out values))
                listDictionary[key] = values = new TValueList();
            values.Add(value);
        }
        public static bool TryGetValue<TKey, TValueList, TValue>(IDictionary<TKey, TValueList> listDictionary, TKey key, int index, out TValue value)
            where TValueList : IList<TValue>
        {
            TValueList list;
            if (!listDictionary.TryGetValue(key, out list))
                return Returns.False(out value);
            if (index < 0 || index >= list.Count)
                return Returns.False(out value);
            value = list[index];
            return true;
        }
        public static bool TryRemoveFirst<TKey, TValueList, TValue>(IDictionary<TKey, TValueList> listDictionary, TKey key, out TValue value)
            where TValueList : IList<TValue>
        {
            TValueList list;
            if (!listDictionary.TryGetValue(key, out list))
                return Returns.False(out value);
            int count = list.Count;
            if (count > 0)
            {
                value = list[0];
                list.RemoveAt(0);
                if (--count == 0)
                    listDictionary.Remove(key);
                return true;
            }
            else
            {
                listDictionary.Remove(key); // Error?
                return Returns.False(out value);
            }
        }
    }
    public static class Returns
    {
        public static bool False<TValue>(out TValue value)
        {
            value = default(TValue);
            return false;
        }
    }
