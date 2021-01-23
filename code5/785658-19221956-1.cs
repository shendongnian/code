    public static bool LoadNodesFromXML()
        {
            XDocument doc = XDocument.Load(@"D:\\path.xml");
            var root = doc.Root;
            var childenode = dcselectview.Nodes.Add(root.Attribute("Name").Value);
            foreach (var xElement in root .Elements())
                    {
                        InsertNode(childenode, xElement);
                    }
    }
    
    
    private void InsertNode(TreeNode parent, XElement element)
            {
                var childenode = parent.Nodes.Add(element.Attribute("Name").Value);
                if(element.Elements().Count() > 0)
                    foreach (var xElement in element.Elements())
                    {
                        InsertNode(childenode, xElement);
                    }
    
            }
