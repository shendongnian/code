        private void DisplayTreeView(string pathname)
        {
            try
            {
                // SECTION 1. Create a DOM Document and load the XML data into it.
                XmlDocument dom = new XmlDocument();
                dom.Load(pathname);
                // SECTION 2. Initialize the TreeView control.
                treeView1.Nodes.Clear();
                // SECTION 3. Populate the TreeView with the XML nodes.
                foreach (XmlNode xNode in dom.ChildNodes)
                {
                    var tNode = treeView1.Nodes[treeView1.Nodes.Add(new TreeNode(xNode.Name))];
                    AddNode(xNode, tNode);
                }
            }
            catch (XmlException xmlEx)
            {
                MessageBox.Show(xmlEx.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
