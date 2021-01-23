    public class A
    {
        public virtual string Property1 { get; set; }
        public virtual string Property2 { get; set; }
    }
    
    public class B : A
    {
    	public override string Property1 { get { return base.Property1; } set { base.Property1 = value; } }
    	public override string Property2 { get { return base.Property2; } set { base.Property2 = value; } }
    }
    
    public class C : A
    {
    	public override string Property1 { get { return base.Property1; } set { base.Property1 = value; } }
    	public override string Property2 { get { return base.Property2; } set { base.Property2 = value; } }
    }
