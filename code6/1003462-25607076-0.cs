    public abstract class BaseClassFromLibrary : IDisposable
    {
        public abstract void Dispose();
    }
    public class MyClass : BaseClassFromLibrary
    {
        public override void Dispose()
        {
        }
    }
