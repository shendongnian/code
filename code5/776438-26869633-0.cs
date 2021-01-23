    public interface IWorker
    {
        void DoWork();
    }
    // wrap engineer in engineering.dll
    public class Engineer:IWorker
    {
        public void DoWork(){...}
    }
    // wrap Chef in logistics.dll
    public class Chef:IWorker
    {
        public void DoWork(){...}
    }
    // and now load interface from dll
    IWorker LoadWorkerInterface(string libName, string typeName)
    {
        Assembly assy=Assembly.LoadFrom(libName);
        Type t=assy.GetType(typeName);
        return Activator.CreateInstance(t) as IWorker;
    }
    
