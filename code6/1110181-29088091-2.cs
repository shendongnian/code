    public void exportToXml(TreeView tv, string filename)
        {
            sr = new StreamWriter(filename, false, System.Text.Encoding.UTF8);
            //Write the header
            sr.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\" ?>");
            //Write our root node
            sr.WriteLine("<" + treeView1.Nodes[0].Text + ">");
            foreach (TreeNode node in tv.Nodes)
            {
                int depth = 1;
                saveNode(node.Nodes, depth);
            }
            //Close the root node
            sr.WriteLine("</" + treeView1.Nodes[0].Text + ">");
            sr.Close();
        }
        private void saveNode(TreeNodeCollection tnc, int depth)
        {
            foreach (TreeNode node in tnc)
            {
                for(int i =0; i<depth;i++)
                {
                    sr.Write("\t");
                }
                if (node.Nodes.Count > 0)
                {
                    sr.WriteLine("<" + node.Text + ">");
                    saveNode(node.Nodes, depth + 1);
                    for(int i =0; i<depth;i++)
                    {
                        sr.Write("\t");
                    }
                    sr.WriteLine("</" + node.Text.split(' ')[0] + ">");
                }
                else //No child nodes, so we just write the text
                    sr.WriteLine("\t"+node.Text);    
            }    
        }
	
