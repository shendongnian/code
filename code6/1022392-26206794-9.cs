    Node a = new Node("A");
    Node b = new Node("B");
    Node c = new Node("C");
    Node d = new Node("D");
    Node e = new Node("E");
    
    a.Edges.Add(new Edge(5, b));
    a.Edges.Add(new Edge(7, e));
    a.Edges.Add(new Edge(5, d));
    b.Edges.Add(new Edge(4, c));
    c.Edges.Add(new Edge(2, e));
    c.Edges.Add(new Edge(8, d));
    d.Edges.Add(new Edge(8, c));
    d.Edges.Add(new Edge(6, e));
    e.Edges.Add(new Edge(3, b));
