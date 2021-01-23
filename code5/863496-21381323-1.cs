    public class Border
    {
        private readonly int bottom;
        private readonly int left;
        private readonly int right;
        private readonly int top;
        public Border(int top, int left, int bottom, int right)
        {
            this.top = top;
            this.left = left;
            this.bottom = bottom;
            this.right = right;
        }
        protected bool Equals(Border other)
        {
            return bottom == other.bottom && left == other.left && right == other.right && top == other.top;
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Border) obj);
        }
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = bottom;
                hashCode = (hashCode*397) ^ left;
                hashCode = (hashCode*397) ^ right;
                hashCode = (hashCode*397) ^ top;
                return hashCode;
            }
        }
        public static bool operator ==(Border left, Border right)
        {
            return Equals(left, right);
        }
        public static bool operator !=(Border left, Border right)
        {
            return !Equals(left, right);
        }
        public int Top
        {
            get { return top; }
        }
        public int Bottom
        {
            get { return bottom; }
        }
        public int Left
        {
            get { return left; }
        }
        public int Right
        {
            get { return right; }
        }
    }
