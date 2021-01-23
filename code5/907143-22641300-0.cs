    public void ArrayListSort()
    {
        var list = new ArrayList();
        list.Sort(new LengthComparer());
    }
    class LengthComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            var a = x as ArrayList;
            var b = y as ArrayList;
            // check for null if you need to!
            return a.Count.CompareTo(b.Count);
        }
    }
