    public class Parent
        {
            public int MyProperty { get; set; }
    
            public virtual Parent MyMethod()
            {
                return new Parent();
            }
        }
    
        public class A : Parent
        {
            public override Parent MyMethod()
            {
                return new A();
            }
        }
