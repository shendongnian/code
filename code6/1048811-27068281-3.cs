    class Module1
    {
        public string Name { get { return "Module 1"; } } 
    }
    public void PrintModuleName(string moduleType)
    {
        Type tModule = Type.GetType("MyApp.Module1");
        dynamic module = Activator.CreateInstance(tModule);
        Console.WriteLine(module.Name); 
    }
