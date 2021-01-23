    public interface IPropertyHolder
    {
        string this[string attributeName] { get; }
        void SetAttribute(string attribute, string value);
        string GetAttribute(string attribute);
    }
    public interface INodeParent<T>
    {
        IList<T> Children { get; }
    }
    public interface INodeChild<T>
    {
        T Parent { get; set; }
    }
    public interface INode
    {
        string Tag { get; set; }
        string ValueAsString { get; set; }
        object Value { get; }
    }
    public interface ITreeNode : INode, IPropertyHolder, INodeParent<ITreeNode>, INodeChild<ITreeNode>
    {
    }
