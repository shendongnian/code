    class FactorTreeNode
    {
        public FactorTreeNode(int key) { this.Key = key; }
        public FactorTreeNode Left { get; set; }
        public FactorTreeNode Right { get; set; }
        public int Key { get; private set; }
    }
