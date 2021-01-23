    public IEnumerable<Node> ActiveNodes {
        get {
            return this.Nodes.Where(node => node.Active);
        }
    }
