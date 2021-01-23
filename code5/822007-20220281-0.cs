    public class Class1 : IEquatable<Class1>
    {    
        public sealed override bool Equals(object obj)
        {
            return Equals(obj as Class1);
        }
        
        public virtual bool Equals(Class1 obj)
        {
            if(ReferenceEquals(obj, null))
                return false;
            
            // Some property checking
        }
    }
    
    public class Class2 : Class1, IEquatable<Class2>
    {
        public sealed override bool Equals(Class1 obj)
        {
            return Equals(obj as Class2);
        }
        
        public virtual bool Equals(Class2 obj)
        {
            if(!base.Equals(obj))
                return false;
            
            // Some more property checking
        }
    }
    
    public class Class3 : Class2, IEquatable<Class3>
    {
        public sealed override bool Equals(Class2 obj)
        {
            return Equals(obj as Class3);
        }
        
        public virtual bool Equals(Class3 obj)
        {
            if(!base.Equals(obj))
                return false;
        
            // Some more property checking
        }
    }
