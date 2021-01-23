    public abstract class User 
    {
        protected void PrepareUser()
        {
           // init
        }
        protected abstract void Display();
    }
  
    public class Person : User
    {
       // override display
        protected override void Display()
        {
           // Do Stuff
        }
    }
