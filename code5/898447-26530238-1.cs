    //Base class for plugins. It has to be delivered from MarshalByRefObject,
    //cause we will want to get it's proxy in our main domain. 
    public abstract class MyPluginBase : MarshalByRefObject
    {
        public abstract event EventHandler MyEvent;
        protected MyPluginBase()
        { }
        public abstract void TestEvent();
    }
    //Helper class which instance will exist in destination AppDomain, and which 
    //TransparentProxy object will be used in home AppDomain
    public class MyPluginFactory : MarshalByRefObject
    {
        //public event EventHandler MyEvent;
        //This method will be executed in destination AppDomain and proxy object
        //will be returned to home AppDomain.
        public MyPluginBase CreatePlugin(string assemblyName, string typeName)
        {
            Console.WriteLine("[appdomain:{0}] CreatePlugin {1} {2}", AppDomain.CurrentDomain.FriendlyName, assemblyName, typeName);
            return (MyPluginBase)Activator.CreateInstance(assemblyName, typeName).Unwrap();
        }
    }
