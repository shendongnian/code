    public void findAllNodes(XElement node)
    {
        Console.Write("{0}:", node.Name.ToString());
    
        Console.WriteLine(node.Value);
        Console.WriteLine("{0}"," ");
        foreach (XElement n in node.Elements())
            findAllNodes(n);
    }
    
    findAllNodes(XElement.Load(file));
