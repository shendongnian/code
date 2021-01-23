    public class D { public int Id { get; set; } }
    public class C {
        public IEnumerable<D> Ds { get; set; }
    }
    public class B
    {
        public IEnumerable<C> Cs { get; set; }
    }
    public class A
    {
        public IEnumerable<B> Bs { get; set; }
    }
