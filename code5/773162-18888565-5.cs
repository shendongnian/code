    private sealed class ReferenceComparer : System.Collections.Generic.IEqualityComparer<object>
    {
        public readonly static ReferenceComparer Default = new ReferenceComparer();
        private ReferenceComparer() {}
        bool System.Collections.Generic.IEqualityComparer<object>.Equals(object x, object y)
        {
            return x == y; // ref equality
        }
        int System.Collections.Generic.IEqualityComparer<object>.GetHashCode(object obj)
        {
            return System.Runtime.CompilerServices.RuntimeHelpers.GetHashCode(obj);
        }
    }
