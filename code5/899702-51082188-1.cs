    asm = Assembly.LoadFrom(dllPath);
    Type typeClass = asm.GetType("RemoteControl");
    obj = System.Activator.CreateInstance(typeClass);
    Type[] types = asm.GetTypes();
    Type TEnum = types.Where(d => d.Name == "RemoteButtons").FirstOrDefault();
    MethodInfo method = typeClass.GetMethod("Push", new Type[] { TEnum});
    object[] parameters = new object[] { RemoteButtons.Play };
    method.Invoke(obj, parameters);
