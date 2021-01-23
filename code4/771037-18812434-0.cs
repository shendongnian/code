    public interface IMyInterface
    {
        int MyProperty
        {
            get;
        }
    }
    public abstract class MyBaseClass : IMyInterface
    {
        public abstract int MyProperty
        {
            get;
            protected set;<--add set accessor here
        }
    }
    public class MyClass : MyBaseClass
    {
        public override int MyProperty
        {
            get
            {
                return 0;
            }
            protected set //this works
            {
            }
        }
    }
