    public interface IDynamicService {
        void DoSomething();
    }
    
    public void static main() {
        var assembly = Assembly.LoadFrom("filepath"); 
        var aClass = assembly.GetType("NameSpace.AClass");
        IDynamicService instance = Activator.CreateInstance(aClass) as IDynamicService;
        
        if (instance != null) {
            instance.DoSomething();
        }
    }
