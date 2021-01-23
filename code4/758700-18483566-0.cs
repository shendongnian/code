    Assembly assembly = Assembly.GetExecutingAssembly();
    Type type = assembly.GetType("Util");
    MethodInfo methodInfo = type.GetMethod("SendClient");
    
    methodInfo.Invoke(Activator.CreateInstance(type), new object[] { Packet.GetData()});
