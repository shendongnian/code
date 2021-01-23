    public Form1()
    {
        InitializeComponent();
    
        var namespaceStrings = new String[]
        {
            "Enums.NEWENUMS.NEW1",
            "Enums.NEWENUMS.NEW2",
            "Enums.NEWENUMS.NEW3",
            "Enums.OLDENUMS",
            "Enums.TEST.SUB",
            "Enums.TEST.SUB.OK"
        };
    
        var namespaces = Namespace.FromStrings(namespaceStrings);
       
        AddNamespaces(this.treeView_Namespaces.Nodes, namespaces);
    }
    
    void AddNamespaces(TreeNodeCollection nodeCollection, IEnumerable<Namespace> namespaces)
    {
        foreach (var aNamespace in namespaces)
        {
            TreeNode node = new TreeNode(aNamespace.NameOnLevel);
            nodeCollection.Add(node);
    
            AddNamespaces(node.Nodes, aNamespace.Subnamespaces);
            node.Expand();
        }
    }
