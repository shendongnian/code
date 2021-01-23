    public interface IPluginStrategy
    {
        void SomeMethod();
    }
    public class OldPluginStrategy : IPluginStrategy
    {
        public void SomeMethod()
        {
             // old plugin code
        }
    }
    public class NewPluginStrategy : IPluginStrategy
    {
        public void SomeMethod()
        {
             // new plugin code which might be using OldPuginStrategy
             // through inheritance or composition
        }
    }
