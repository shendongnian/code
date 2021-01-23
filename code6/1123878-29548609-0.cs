    using System;
    
    namespace UnitTestProject3
    {
        public interface IFoo
        {
            int GetAllTheFoo();
        }
    
        public interface IInitialiser
        {
            void Initialise(int x);
    
            int GetX();
    
            bool IsReady { get; }
        }
    
        public class Foo : IFoo
        {
            private bool isInitalised;
            private int x;
            private IInitialiser i;
            public Foo(IInitialiser i)
            {
                this.isInitalised = false;
                this.i = i;
            }
    
            protected void Init()
            {
                if (this.isInitalised)
                {
                    return;
                }
                else if (i.IsReady)
                {
                    x = i.GetX();
                    this.isInitalised = true;
                    return;
                }
                else
                {
                    throw new Exception("you have not set x");
                }
            }
    
            public int GetAllTheFoo()
            {
                Init();
                return x;
            }
        }
    
    }
