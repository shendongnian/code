    public class A {
        public A() 
        {
            this.Bs = new Collection<B>();
        }
        public int Id { get; set; }
        public virtual ICollection<B> Bs { get; set; }
    }
