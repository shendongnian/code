     public abstract class A
        {
            public A()
            {
                ExecuteConstructor();
            }
    
            protected abstract void ExecuteConstructor();
        }
    
        public class B : A
        {
            public B() { }
    
            protected override void ExecuteConstructor()
            {
                // implementation of your constructor to run in A 
            }
        }
