                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Title = "Open XML Document";
                dlg.Filter = "XML Files (*.xml)|*.xml";
                dlg.FileName = Application.StartupPath + "\\..\\..\\example.xml";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        //Just a good practice -- change the cursor to a 
                        //wait cursor while the nodes populate
                        this.Cursor = Cursors.WaitCursor;
                        //First, we'll load the Xml document
                        XmlDocument xDoc = new XmlDocument();
                        xDoc.Load(dlg.FileName);        
                        //Now, clear out the treeview, 
                        //and add the first (root) node
                        treeView1.Nodes.Clear();
                        treeView1.Nodes.Add(new 
                          TreeNode(xDoc.DocumentElement.Name));
                        TreeNode tNode = new TreeNode();
                        tNode = (TreeNode)treeView1.Nodes[0];
                        //We make a call to addTreeNode, 
                        //where we'll add all of our nodes
                        addTreeNode(xDoc.DocumentElement, tNode);
                        //Expand the treeview to show all nodes
                        treeView1.ExpandAll();    
                    }
                    catch(XmlException xExc) 
                      //Exception is thrown is there is an error in the Xml
                    {
                        MessageBox.Show(xExc.Message);
                    }
                    catch(Exception ex) //General exception
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        this.Cursor = Cursors.Default; //Change the cursor back
                    }
                }
            }
            //This function is called recursively until all nodes are loaded
            private void addTreeNode(XmlNode xmlNode, TreeNode treeNode)
            {
                XmlNode xNode;
                TreeNode tNode;
                XmlNodeList xNodeList;
                if (xmlNode.HasChildNodes) //The current node has children
                {
                    xNodeList = xmlNode.ChildNodes;
                    for(int x=0; x<=xNodeList.Count-1; x++) 
                      //Loop through the child nodes
                    {
                        xNode = xmlNode.ChildNodes[x];
                        treeNode.Nodes.Add(new TreeNode(xNode.Name));
                        tNode = treeNode.Nodes[x];
                        addTreeNode(xNode, tNode);
                    }
                }
                else //No children, so add the outer xml (trimming off whitespace)
                    treeNode.Text = xmlNode.OuterXml.Trim();
            }
    </pre>
