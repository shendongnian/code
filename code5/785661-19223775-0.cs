    XDocument doc = XDocument.Load(@"path\\test.xml");            
            // Add nodes to treeView1.
            TreeNode pnode;
            TreeNode cnode;
                var gnrl = from general in doc.Descendants("general")
                           select new
                           {
                               parent = general.Attribute("name").Value,
                               child = general.Descendants("service")
                           };
                //Loop through results
                foreach (var general in gnrl)
                {
                     // Add a root node.
                pnode = treeview.Nodes.Add(String.Format(general.parent));
                    foreach (var ser in general.child)
                    {
                    // Add a node as a child of the previously added node.
                    cnode = pnode.Nodes.Add(String.Format(ser.Attribute("name").Value));                        
                    }
               }
