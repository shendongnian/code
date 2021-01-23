    namespace MyNamespace
    {
        public class XXX
        {
            protected abstract class User
            {
                protected void PrepareUser()
                {
                    // init
                }
    
                protected abstract void  Display();
            }
    
            protected class Person : User
            {
                protected override void Display()
                {
                    //something
                }
            }
        }
    }
    
