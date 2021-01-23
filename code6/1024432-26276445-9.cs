    interface IHierarchical<T> : IHierarchicalIn<T>, IHierarchicalOut<T>
    {
    }
    interface IHierarchicalIn<in T>
    {
        T Parent { set; }
    }
    interface IHierarchicalOut<out T>
    {
        T Parent { get; }
    }
    class Node : IHierarchical<Node>
    {
        public Node Parent
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }
    }
