    public interface INode
    {
        string Name { get; }
    }
    public class List
    {
        private class Node : INode
        {
            public string Name { get; set; }
            public Node Next { get; set; }
        }
        private List<Node> _items = new List<Node>();
        public INode GetItemAt(int index)
        {
            return _items[index];
        }
        public INode GetNextItem(INode item)
        {
            return (item is Node) ? ((Node)item).Next : null;
        }
    }
