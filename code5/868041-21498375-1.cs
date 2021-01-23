    public abstract class BaseClass1
    {
        public abstract string Method();
    }
    public abstract class BaseClass2 : BaseClass1
    {
    }
    public class UserClass : BaseClass2
    {
        string name;
        public override string Method()
        {
          return name;
        }
    }
