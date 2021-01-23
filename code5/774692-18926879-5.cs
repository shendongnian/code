    class Program
    {
        static void Main()
        {
            var path = "Types+Types.People+Name";
            var path2 = "Types+Types.People+CallMe";
            var path3 = "Types+Types.People+NoReturn";
            var instance1 = new DynamicInvoke(path);
            var instance2 = new DynamicInvoke(path, "Jill");
            var instance3 = new DynamicInvoke(path2);
            var instance4 = new DynamicInvoke(path2, "Johnny");
            var instance5 = new DynamicInvoke(path3);
            instance1.DynamicPropertySet("Tom");
            sc.WriteLine(instance1.DynamicPropertyGet<string>());
            sc.WriteLine(instance2.DynamicPropertyGet<string>());
            sc.WriteLine(instance3.DynamicMethodInvoke<string>());
            sc.WriteLine(instance4.DynamicMethodInvoke<string>("Timmy"));
            instance5.DynamicMethodInvoke<object>();
            
            Console.Read();
        }
    }
