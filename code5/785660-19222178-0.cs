    public static class TreeViewExtension
    {
        public static bool LoadNodesFromXML(this TreeView tv, string xml)
        {
            try
            {
                XDocument doc = XDocument.Parse(xml);
                TreeNode rootNode = new TreeNode();
                rootNode.Text = doc.Root.ToString().Split('>')[0] + ">";
                rootNode.LoadTreeNodes(doc.Root.Elements());
                tv.Nodes.Add(rootNode);
                return true;
            }
            catch { return false; }
        }
        public static void LoadTreeNodes(this TreeNode parentNode, IEnumerable<XElement> elements)
        {
            foreach (var e in elements) {
                TreeNode childNode = new TreeNode();                
                childNode.Text = e.ToString().Split('>')[0] + ">";
                parentNode.Nodes.Add(childNode);
                childNode.LoadTreeNodes(e.Elements());
            }
        }
    }
    //Usage:
    var yourInputXMLString = "<servers><general name=\"1\"><service name=\"ser1\"/>" +
                             "<service name=\"ser2\"/></general><general name=\"2\">" +
                             "<service name=\"ser1\"/><service name=\"ser2\"/>" +
                             "</general></servers>";
    treeView1.LoadNodesFromXML(yourInputXMLString);
