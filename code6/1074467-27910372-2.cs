    List<fi> files = new List<fi>()
    {
        new fi(new DateTime(2001, 1, 1), "File 1"),
        new fi(new DateTime(2001, 1, 1), "File 2"),
        new fi(new DateTime(2001, 1, 3), "File 3"),
        new fi(new DateTime(2001, 1, 1), "File 4"),
        new fi(new DateTime(2001, 1, 2), "File 5"),
        new fi(new DateTime(2001, 1, 2), "File 6"),
        new fi(new DateTime(2001, 1, 2), "File 7")
    };
    TreeView tv = new TreeView();
    var orderedfiles = from file in files orderby file.date ascending select file;
    foreach(fi file in orderedfiles)
    {
        TreeNode Node = tv.Nodes[file.date.Year.ToString()] ?? tv.Nodes.Add(file.date.Year.ToString(), file.date.Year.ToString());
        Node = Node.Nodes[file.date.ToString("yyyy-mm")] ?? Node.Nodes.Add(file.date.ToString("yyyy-mm"), file.date.ToString("yyyy-mm"));
        Node = Node.Nodes[file.date.ToString("yyyy-mm-dd")] ?? Node.Nodes.Add(file.date.ToString("yyyy-mm-dd"), file.date.ToString("yyyy-mm-dd"));
        Node.Nodes.Add(file.fn);
    }
