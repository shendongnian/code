        private void AddNode(XmlNode inXmlNode, TreeNode inTreeNode)
        {
            if (inXmlNode is XmlElement)
            {
                // An element.  Display element name + attribute names & values.
                foreach (var att in inXmlNode.Attributes.Cast<XmlAttribute>().Where(a => !a.IsNamespaceDeclaration()))
                {
                    inTreeNode.Text = inTreeNode.Text + " " + att.Name + ": " + att.Value;
                }
                // Add children
                foreach (XmlNode xNode in inXmlNode.ChildNodes)
                {
                    var tNode = inTreeNode.Nodes[inTreeNode.Nodes.Add(new TreeNode(xNode.Name))];
                    AddNode(xNode, tNode);
                }
            }
            else
            {
                // Not an element.  Character data, comment, etc.  Display all text.
                inTreeNode.Text = (inXmlNode.OuterXml).Trim();
            }
            treeView1.ExpandAll();
        }
