    public abstract class Base
        {
            public int val { get; set; }
    
            public abstract bool Merge<T>(T obj) where T:Base;
        }
    
        public class A : Base
        {
            public A(int val)
            {
                this.val = val;
            }
    
            public override bool Merge<A>(A obj)
            {
                if (obj.GetType() != GetType())
                    return false;
    
                val += obj.val;
                return true;
            }
        }
    
        public class B : Base
        {
            public B(int val)
            {
                this.val = val;
            }
    
            public override bool Merge<B>(B obj)
            {
                if (obj.GetType() != GetType())
                    return false;
    
                val += obj.val;
                return true;
            }
        }
    
        public class Composite
        {
            List<Base> objects = new List<Base>();
    
            public void addObject(Base obj)
            {
                foreach (Base b in this.objects)
                {
                    if (b.Merge(obj))
                        return;
                }
    
                this.objects.Add(obj);
            }
        }
