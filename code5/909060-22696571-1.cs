    public class Node : IEquatable<Node>, IComparable<Node>
    {
        public int X, Y;
        public int rand;
        public Node(int x, int y, int r)
        { X = x; Y = y; rand = r; }
        public bool Equals(Node other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return X == other.X && Y == other.Y && rand == other.rand;
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Node)obj);
        }
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = X;
                hashCode = (hashCode*397) ^ Y;
                hashCode = (hashCode*397) ^ rand;
                return hashCode;
            }
        }
        public int CompareTo(Node other)
        {
            //First order by X then order by Y then order by rand
            var result = X.CompareTo(other.X);
            if (result != 0)
                return result;
            result = Y.CompareTo(other.Y);
            if (result != 0)
                return result;
            return rand.CompareTo(other.rand);
        }
    }
