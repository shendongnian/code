    public class ValSeqGroupComparer : IComparer<ValSeqGroup>
    {
        public int Compare(ValSeqGroup x, ValSeqGroup y)
        {
            if (x == y) return 0;
            // If only one has a group or there is no group in either
            if (x.Group.HasValue ^ y.Group.HasValue || !x.Group.HasValue)
                return x.Seq.CompareTo(y.Seq);
            if (x.Group.Value != y.Group.Value)
                return x.Group.Value.CompareTo(y.Group.Value);
            return x.Seq.CompareTo(y.Seq);
        }
    }
