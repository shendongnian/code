    public interface INode
    {
        string Name { get; }
    }
    public class List
    {
        private class Node : INode
        {
            public string Name { get; set; }
        }
        private List<Node> _items = new List<Node>();
        public INode GetItemAt(int index)
        {
            return _items[index];
        }
    }
