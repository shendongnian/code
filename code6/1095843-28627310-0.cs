     Assembly assembly = Assembly.LoadFile(path);
     Type t = assembly.GetType("YourClassName");
     object instance = Activator.CreateInstance(t);
     int parameter1 = 1;
     object result = t.GetMethod("The MethodName").Invoke(instance, new object[] { parameter1, "Something" });
