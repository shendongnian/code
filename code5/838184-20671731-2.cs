    class FactorTreeNode
    {
        public FactorTreeNode(long key) { this.Key = key; }
        public FactorTreeNode Left { get; set; }
        public FactorTreeNode Right { get; set; }
        public long Key { get; private set; }
    }
