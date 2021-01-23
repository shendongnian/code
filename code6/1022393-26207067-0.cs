    IEnumerable<Path> FindAllPaths(Node from, Node to)
    {
        Queue<Tuple<Node, List<Node>>> nodes = new Queue<Tuple<Node, List<Node>>>();
        nodes.Enqueue(new Tuple<Node, List<Node>>(from, new List<Node>()));
        List<Path> paths = new List<Path>();
    
        while(nodes.Any())
        {
            var current = nodes.Dequeue();
            Node currentNode = current.Item1;
    
            if (current.Item2.Contains(currentNode))
            {
                continue;
            }
    
            current.Item2.Add(currentNode);
    
            if (currentNode == to)
            {
                paths.Add(new Path(current.Item2));
                continue;
            }
    
            foreach(var edge in current.Item1.Edges)
            {
                nodes.Enqueue(new Tuple<Node, List<Node>>(edge.Target, new List<Node>(current.Item2)));
            }
        }
    
        return paths;
    } 
