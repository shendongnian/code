    public class Ring : IComparer
    {
        public decimal Price { get; set; }
    
        public int Compare(object x, object y)
        {
            return ((Ring)x).Price.CompareTo(((Ring)y).Price);
        }
    }
