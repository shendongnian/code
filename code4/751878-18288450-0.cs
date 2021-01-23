    public static class MutableTuple
    {
        public static MutableTuple<T1, T2, T3> Create<T1, T2, T3>(T1 item1, T2 item2, T3 item3)
        {
            return new MutableTuple<T1, T2, T3>(item1, item2, item3);
        }
    }
    [Serializable]
    public class MutableTuple<T1, T2, T3> : IComparable, IStructuralEquatable, IStructuralComparable
    {
        public T1 Item1 { get; set; }
        public T2 Item2 { get; set; }
        public T3 Item3 { get; set; }
        public MutableTuple(T1 item1, T2 item2, T3 item3)
        {
            this.Item1 = item1;
            this.Item2 = item2;
            this.Item3 = item3;
        }
        public override bool Equals(object obj)
        {
            return this.Equals(obj, EqualityComparer<object>.Default);
        }
        public override int GetHashCode()
        {
            return this.GetHashCode(EqualityComparer<object>.Default);
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(this.Item1);
            sb.Append(", ");
            sb.Append(this.Item2);
            sb.Append(", ");
            sb.Append(this.Item3);
            sb.Append(")");
            return sb.ToString();
        }
        public int CompareTo(object obj)
        {
            return this.CompareTo(obj, Comparer<object>.Default);
        }
        public bool Equals(object obj, IEqualityComparer comparer)
        {
            if (obj == null)
            {
                return false;
            }
            var tuple = obj as MutableTuple<T1, T2, T3>;
            return tuple != null && (comparer.Equals(this.Item1, tuple.Item1) && comparer.Equals(this.Item2, tuple.Item2)) && comparer.Equals(this.Item3, tuple.Item3);
        }
        public int GetHashCode(IEqualityComparer comparer)
        {
            unchecked
            {
                int hash = 17;
                hash = (hash * 23) + comparer.GetHashCode(this.Item1);
                hash = (hash * 23) + comparer.GetHashCode(this.Item2);
                hash = (hash * 23) + comparer.GetHashCode(this.Item3);
                return hash;
            }
        }
        public int CompareTo(object obj, IComparer comparer)
        {
            if (obj == null)
            {
                return 1;
            }
            var other = obj as MutableTuple<T1, T2, T3>;
            if (other == null)
            {
                throw new ArgumentException();
            }
            int res = comparer.Compare(this.Item1, other.Item1);
            if (res != 0)
            {
                return res;
            }
            res = comparer.Compare(this.Item2, other.Item2);
            if (res != 0)
            {
                return res;
            }
            res = comparer.Compare(this.Item3, other.Item3);
            return res;
        }
    }
