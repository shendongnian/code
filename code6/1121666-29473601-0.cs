    public class Component : CustomBase
    {
        public void Test()
        {
          console.log("test");
        }
    }
    public abstract class CustomBase
    {
        public CustomBase()
        {
            bool foo = false;
            if (foo)
                Console.WriteLine ("TRUE");
        }
    }
