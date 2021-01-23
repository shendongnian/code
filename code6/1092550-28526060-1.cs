    public ICollection<Vertex> vertices()
    { 
        return graph.values(); 
    }
 
    public IList<Vertex> vertices()
    { 
        return graph.values().ToList(); 
    }
