    public class NodeComparer : IComparer<Node>, IEqualityComparer<Node>
    {
        public int Compare(Node node1, Node node2)
        {
            //Sorts by X then by Y
            //perform the X comparison
            var result = node1.X.CompareTo(node2.X);
            if (result != 0)
                return result;
            //Perform the Y Comparison
            return node1.Y.CompareTo(node2.Y);
        }
        public bool Equals(Node x, Node y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (ReferenceEquals(x, null)) return false;
            if (ReferenceEquals(y, null)) return false;
            if (x.GetType() != y.GetType()) return false;
            return x.X == y.X && x.Y == y.Y && x.rand == y.rand;
        }
        public int GetHashCode(Node obj)
        {
            unchecked
            {
                var hashCode = obj.X;
                hashCode = (hashCode * 397) ^ obj.Y;
                hashCode = (hashCode * 397) ^ obj.rand;
                return hashCode;
            }
        }
    }
    public class Node
    {
        public int X, Y;
        public int rand;
    
        public Node(int x, int y, int r)
        { X = x; Y = y; rand = r; }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            SortedSet<Node> mySet = new SortedSet<Node>(new NodeComparer());
            mySet.Add(new Node(1, 2, 90));
            Node myNode = new Node(1, 2, 50);
            // I want this to check if X and Y are the same
            if (mySet.Contains(myNode, interfaceThing))
                Console.WriteLine("Sth is already on that (X, Y) position");      
        }
    }
