    using System.Reflection;
    using System.Diagnostics;
    //Using two namespaces more above
    public class A 
    {
        private string info;
        public string Info
        {
            get
            {
                return this.info;
            }
            set
            {
                this.info = value;
            }
        }
        //I like this writing better
        /* much more data */
    }
    
    public class B
    {
        private A m_instanceOfA;
    
        public B(A a)
        {
            this.m_instanceOfA = a; //I will prefer to add 'this' to non-local variables.
        }
    
        public string Info //Added 'string' between 'public' and 'Info', because before it was error
        {
             get
             {
                 return this.m_instanceOfA.Info; //Write the name of the field, not his type. Info is not static
             }
             set
             {
                 this.m_instanceOfA.Info = value; //Same as above in get
             }
             //Added '{' and '}' in get and set, because they are methods after all
        }
        
        //Added the following code
        private readonly ConstructorInfo friend = typeof(C).GetConstructor(new Type[] { typeof(B) });
        public A InstanceOfA
        {
            get
            {
                if (new StackFrame(1).GetMethod() != this.friend)
                   throw new Exception("Call this property only inside the constructor of C");
                return this.m_instanceOfA;
            }
        }
    
        /* And some more data of its own*/
    }
    
    public class C
    {
        private A m_instanceOfA;
    
        // Only the constructor of C can set his m_instanceOfA
        // to the same value as b.m_instanceOfA.
        public C(B b)
        {
            this.m_instanceOfA = b.InstanceOfA; //Call the public property, not the private field. Now it is allowed and it will work too, because you call it inside the constructor of C. In Main method, for example, an exception will be thrown, if you try to get InstanceOfA there.
        }
    
        /* And some more data of its own*/
    }
