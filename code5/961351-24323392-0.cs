    protected abstract class User{
        protected void PrepareUser()
        {
          // init
        }
    
        protected abstract void Display();
    }
    
    public class Person: User{
        protected override void Display()
        {
            // ...implementation...
        }
    }
