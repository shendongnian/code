    public class TreeNode<T>
        where T:TreeNode<T>
    {
        public T This { get { return this as T;} }
 
        public T Parent { get; set; }
 
        public List<T> Childrens { get; set; }
 
        public virtual void AddChild(T child)
        {
            Childrens.Add(child);
            child.Parent = This;
        }
 
        public virtual void SetParent(T parent)
        {
            parent.Childrens.Add(This);
            Parent = parent;
        }
    }
