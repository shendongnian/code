    var size = Size<MD5>();
---
    public static Byte[] Size<T>()
    {
        dynamic hashFxn = typeof(T).InvokeMember("Create",BindingFlags.Static| BindingFlags.Public | BindingFlags.InvokeMethod,null,null,null);
        return hashFxn.ComputeHash(Encoding.Default.GetBytes("hello"));
    }
