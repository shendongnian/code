    using System.Reflection;
    using System.Diagnostics;
    public class A 
    {
        public string Info { get; set; }
        /* much more data */
    }
    
    public class B
    {
        private A m_instanceOfA;
        public string Info { get; set; }
    
        public B(A a) => Info = a;
        
        private readonly ConstructorInfo friend = typeof(C).GetConstructor(new Type[] { typeof(B) });
        public A InstanceOfA
        {
            get
            {
                if (new StackFrame(1).GetMethod() != friend)
                   throw new Exception("Call this property only inside the constructor of C");
                return this.m_instanceOfA;
            }
        }
    }
    
    public class C
    {
        private A m_instanceOfA;
    
        // Only the constructor of C can set his m_instanceOfA
        // to the same value as b.m_instanceOfA.
        public C(B b)
        {
            Info = b.InstanceOfA; // Call the public property, not the private field. Now it is allowed and it will work too, because you call it inside the constructor of C. In Main method, for example, an exception will be thrown, if you try to get InstanceOfA there.
        }
    }
