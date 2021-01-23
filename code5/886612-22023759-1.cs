    public abstract class MyClassBase
    {
        public abstract Boolean DoWork();
    }
    public class MyClass<T> : MyClassBase where T : BaseClass, new()
    {
        public override Boolean DoWork()
        {
            // do the work, obviously.
        }
    }
