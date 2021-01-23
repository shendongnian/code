        private void LoadXML_Click(object sender, EventArgs e)
        {
            treeView1.BeginUpdate();
            try
            {
                //Add the "Ignored" Top Level node. 
                if (!treeView1.Nodes.ContainsKey("Ignored List"))
                    treeView1.Nodes.Add(new TreeNode { Name = "Ignored List", Text = "Ignored List" });
                var xmldoc = GetXmlDocument(); // From your UI
                int changed = AddOrMergeNodes(xmldoc);
                Debug.WriteLine("Added or removed " + changed + " nodes");
                if (changed > 0)
                {
                    treeView1.ExpandAll();
                    treeView1.Sort();
                }
            }
            finally
            {
                treeView1.EndUpdate();
            }
            treeView1.Focus();
        }
        private void clearXML_Click(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
        }
        static Dictionary<string, List<TreeNode>> ToNodeDictionary(TreeNodeCollection nodes)
        {
            return nodes.Cast<TreeNode>().Aggregate(new Dictionary<string, List<TreeNode>>(), (d, n) => { d.Add(n.Name, n); return d; });
        }
        int AddOrMergeNodes(XmlDocument xmldoc)
        {
            var dict = ToNodeDictionary(treeView1.Nodes);
            return AddOrMergeNode(treeView1.Nodes, dict, xmldoc.DocumentElement);
        }
        static int AddOrMergeNodes(TreeNodeCollection treeNodeCollection, XmlNodeList xmlNodeList)
        {
            int changed = 0;
            var dict = ToNodeDictionary(treeNodeCollection);
            foreach (XmlNode inXmlNode in xmlNodeList)
            {
                changed += AddOrMergeNode(treeNodeCollection, dict, inXmlNode);
            }
            foreach (var leftover in dict.Values.SelectMany(l => l))
            {
                treeNodeCollection.Remove(leftover);
                changed++;
            }
            return changed;
        }
        static int AddOrMergeNode(TreeNodeCollection treeNodeCollection, Dictionary<string, List<TreeNode>> dict, XmlNode inXmlNode)
        {
            int changed = 0;
            var name = inXmlNode.Name;
            TreeNode node;
            if (!dict.TryRemoveFirst(name, out node))
            {
                node = new TreeNode { Name = name, Text = name };
                treeNodeCollection.Add(node);
                changed++;
            }
            Debug.Assert(treeNodeCollection.Contains(node), "treeNodeCollection.Contains(node)");
            if (inXmlNode.HasChildNodes)
            {
                var text = name;
                if (node.Text != text)
                    node.Text = name;
                changed += AddOrMergeNodes(node.Nodes, inXmlNode.ChildNodes);
            }
            else
            {
                var text = (inXmlNode.OuterXml).Trim();
                if (node.Text != text)
                    node.Text = text;
                node.Nodes.Clear();
            }
            return changed;
        }
