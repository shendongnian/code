    public int[][] Signatures
    {
        get
        {
            return Nodes.Select(x => x.Signature).ToArray();
        }
    }
