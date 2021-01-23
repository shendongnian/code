    public class B
    {
        public List<B> Bs { get; set; }
        public List<C> Cs { get; set; }
        public int TotalCs()
        {
            var subtotal = Bs != null ? Bs.Sum(b => b.TotalCs()) : 0;
            return subtotal + Cs.Count;
        }
    }
