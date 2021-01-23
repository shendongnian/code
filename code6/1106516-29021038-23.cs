                // An element.  Display element name + attribute names & values.
                foreach (var att in inXmlNode.Attributes.Cast<XmlAttribute>().Where(a => !a.IsDefaultNamespaceDeclaration()))
                {
                    inTreeNode.Text = inTreeNode.Text + " " + att.Name + ": " + att.Value;
                }
