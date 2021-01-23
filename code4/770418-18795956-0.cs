    class Base
    {
        public virtual void Initialize()
        {
            throw new SomeKindOfException();
        }  
    }
    
    class Derived : Base
    {
        public override void Initialize()
        {
            try
            {
                base.Initialize();
            }
            catch (SomeKindOfException)
            {
                ...
            }
        }
    }
