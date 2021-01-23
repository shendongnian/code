    string xml = ""; // Your big XML string
    StringReader sr = new StringReader(xml);
    XmlSerializer xs = new XmlSerializer(typeof(ListItems));
    ListItems listItems = (ListItems)xs.Deserialize(sr);
    Dictionary<string, TreeNode> nodes = new Dictionary<string, TreeNode>();
    foreach (var item in listItems.Items)
    {
        TreeNode node;
        nodes.Add(item.ID, node = new TreeNode(item.Name));
        if (item.ParentId != null)
            nodes[item.ParentId].Nodes.Add(node);
        else
            treeView1.Nodes.Add(node);
    }
    /* Edited this out, can do in only one loop
    foreach (var item in listItems.Items)
    {
        var children = from i in listItems.Items where i.ParentID == item.ID select i;
        foreach (var child in children)
        {
            nodes[item.ID].Nodes.Add(nodes[child.ID]);
        }
        if (item.ParentID==null)
            treeView1.Nodes.Add(nodes[item.ID]);
    }
    */
