    Console.Write(msgStr);
    var cOut = Console.OpenStandardOutput();
    var handle = cOut.GetType().GetField("_handle", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(cOut);
    var method = Type.GetType("Microsoft.Win32.Win32Native").GetMethod("GetFileType", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
    var type = method.Invoke(null, new object[] { handle });
    Debugger.Break();
