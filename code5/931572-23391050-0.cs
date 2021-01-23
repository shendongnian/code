    public abstract class NodeBase<T> {
      public abstract bool HasChildren { get; }
      public abstract ICollection<T> Children { get; set; }
    }
    public class NodeCollection<T> : NodeBase<T> {
      public override bool HasChildren { get { return true; } }
      public override ICollection<T> Children { get; set; }
    }
    public class Node<T> : NodeBase<T> {
      public override bool HasChildren { get { return false; } }
      public override ICollection<T> Children { get { throw new Exception("blah"); } set { throw new Exception("blah"); } }
    }
