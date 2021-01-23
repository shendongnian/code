    public interface INode<T> where T : INode<T>
    {
        T Parent
        {
            get;
            set;
        }
        // ......
    }
    public interface ISpecificNode : INode<ISpecificNode>
    {
    }
    public class SpecificNode : ISpecificNode
    {
        public ISpecificNode Parent
        {
            get;
            set;
        }
    }
