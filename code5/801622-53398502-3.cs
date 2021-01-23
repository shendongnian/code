    public sealed class TreeNode<T, TKey>
    {
        public T Item { get; set; }
        public TKey ParentId { get; set; }
        public IEnumerable<TreeNode<T, TKey>> Children { get; set; }
    }
