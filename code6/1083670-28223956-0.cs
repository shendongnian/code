    public class A
    {
        public int ID { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<C> Cs { get; set; }
    }
    
    public class B
    {
        public int ID { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<C> Cs { get; set; }
    }
    
    public class C
    {
		public int ID { get; set; }
        public virtual A A { get; set; }
        public virtual B B { get; set; }
        public string OtherProperty { get; set; }
    }
