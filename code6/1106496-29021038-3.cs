        private void AddNode(XmlNode inXmlNode, TreeNode inTreeNode)
        {
            if (inXmlNode is XmlElement)
            {
                // An element or other node with children.  Display element name + value.
                foreach (var att in inXmlNode.Attributes.Cast<XmlAttribute>().Where(a => !a.IsNamespaceDeclaration()))
                {
                    inTreeNode.Text = inTreeNode.Text + " " + att.Name + ": " + att.Value;
                }
            }
            else
            {
                // Not an element.  Character data, comment, ...
                inTreeNode.Text = (inXmlNode.OuterXml).Trim();
            }
            foreach (XmlNode xNode in inXmlNode.ChildNodes)
            {
                var tNode = inTreeNode.Nodes[inTreeNode.Nodes.Add(new TreeNode(xNode.Name))];
                AddNode(xNode, tNode);
            }
            treeView1.ExpandAll();
        }
