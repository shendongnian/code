    private void AddNode(XmlNode inXmlNode, TreeNode inTreeNode)
    {
        XmlNode xNode;
        TreeNode tNode;
        XmlNodeList nodeList;
        int i;
        // Loop through the XML nodes until the leaf is reached.
        // Add the nodes to the TreeView during the looping process.
        if (inXmlNode.HasChildNodes)
        {
            nodeList = inXmlNode.ChildNodes;
            for (i = 0; i <= nodeList.Count - 1; i++)
            {
                xNode = inXmlNode.ChildNodes[i];
                inTreeNode.Nodes.Add(new TreeNode(xNode.Name));
                tNode = inTreeNode.Nodes[i];
                AddNode(xNode, tNode);
            }
        }
        else
        {
            // Here you need to pull the data from the XmlNode based on the
            // type of node, whether attribute values are required, and so forth.
            string text;
            // If the node has an attribute "name", use that.  Otherwise display the entire text of the node.
            XmlAttribute attr = (inXmlNode.Attributes == null ? null : inXmlNode.Attributes["name"]);
            text = (attr == null ? null : attr.Value);
            if (string.IsNullOrEmpty(text))
                text = (inXmlNode.OuterXml).Trim();
            if (inTreeNode.Text != text)
                inTreeNode.Text = text;
        }
    }
