    public bool isAdjacent(GraphNode source, GraphNode destination)
    {
        if (source.AdjList.Contains(destination))
        {
            return true;
        }
        return false;
    }
