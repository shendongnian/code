    class EmptyToEndComparer: StringComparer
    {
        public StringComparer InnerComparer { get; private set; }
        public EmptyToEndComparer(StringComparer innerComparer)
        {
            if (innerComparer == null) throw new ArgumentNullException("innerComparer");
            InnerComparer = innerComparer;
        }
        public override int Compare(string x, string y)
        {
            //Invert the standard behavior on null or empty
            //http://msdn.microsoft.com/en-us/library/x1ea0esc%28v=vs.110%29.aspx
            if (string.IsNullOrEmpty(x) && !string.IsNullOrEmpty(y))
                return 1;
            else if (!string.IsNullOrEmpty(x) && string.IsNullOrEmpty(y))
                return -1;
            else
                return InnerComparer.Compare(x, y);
        }
        public override bool Equals(string x, string y)
        {
            return x == y;
        }
        public override int GetHashCode(string obj)
        {
            return obj.GetHashCode();
        }
    }
