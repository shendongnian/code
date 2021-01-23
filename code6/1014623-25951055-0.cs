    public interface INode
    {
      string Name { get; }
    }
    internal class Node : INode
    {
       // ...
    }
    public class List
    {
      private List<Node> _items;
      public INode GetItemAt(int index)
      {
        return _items[index];
      }
    }
