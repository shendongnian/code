    public IEnumerable<Node> CreateTree(DataTable table)
    {
        var nodes = GetNodes(table);
        var roots = new List<Node>();
        foreach(var node in nodes)
        {
            if(node.ParentId==null)
                roots.Add(node);
            else
            {
                var parent = nodes.Single(n => n.Id == node.ParentId);
                CreateRelationship(parent, node);
            }
        }
    
        return roots;
    }
    
    private void CreateRelationship(Node parent, Node child)
    {
        child.Parent = parent;
        parent.Children.Add(child);
    }
    
    private IEnumerable<Node> GetNodes(DataTable table)
    {
        return from DataRow row in table.Rows select CreateNode(row);
    }
    
    private Node CreateNode(DataRow row)
    {
        return new Node
        {
            Id = Convert.ToInt32(row["PNLId"]),
            ParentId = row.IsNull("PNLParentId") ? default(int?) : Convert.ToInt32(row["PNLParentId"]),
            Operator = Convert.ToString(row["Operator"]),
            Sign = Convert.ToString(row["Sign"])
        };
    }
