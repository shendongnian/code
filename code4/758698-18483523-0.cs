    foreach (Assembly currentassembly in AppDomain.CurrentDomain.GetAssemblies()) 
    {
        Type t = currentassembly.GetType("Util", false, true);
        if (t != null) 
        {
            MethodInfo methodInfo = type.GetMethod("SendClient");
            methodInfo.Invoke(new object[] { Packet.GetData()});
        }
    }
