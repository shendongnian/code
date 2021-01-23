            AppDomain ad = AppDomain.CreateDomain("Isolate DLL");
            Assembly a = ad.Load(new AssemblyName("MyManagedDll"));
            object d = a.CreateInstance("MyManagedDll.MyManagedClass");
            Type t = d.GetType();
            double result = (double)t.InvokeMember("Calculate", BindingFlags.InvokeMethod, null, d, new object[] { 1.0, 2.0 });
            AppDomain.Unload(ad);
