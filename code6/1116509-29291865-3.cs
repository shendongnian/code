    public class A
    {
        public List<B> bs { get; set; }
        public int CountCs()
        {
            return bs.Sum(b => b.TotalCs());
        }
    }
