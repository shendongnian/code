    [StructLayout(LayoutKind.Sequential)]
    public struct _Key
    {
        public IntPtr keyName;
        public uint keySize;
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct _KeyHolder
    {
        public string name;
        public uint numKeys;
        public IntPtr keys;
    }
    public struct Key
    {
        public string keyName;
        public uint keySize;
    }
    public static _KeyHolder CreateKeyHolder(string name, Key[] keys)
    {
        _KeyHolder result;
        result.name = name;
        result.numKeys = (uint)keys.Length;
        result.keys = Marshal.AllocHGlobal(keys.Length * Marshal.SizeOf(typeof(_Key)));
        IntPtr ptr = result.keys;
        for (int i = 0; i < result.numKeys; i++)
        {
            _Key key;
            key.keyName = Marshal.StringToHGlobalAnsi(keys[i].keyName);
            key.keySize = keys[i].keySize;
            Marshal.StructureToPtr(key, ptr, false);
            ptr += Marshal.SizeOf(typeof(_Key));
        }
        return result;
    }
    public static void DestroyKeyHolder(_KeyHolder keyHolder)
    {
        IntPtr ptr = keyHolder.keys;
        for (int i = 0; i < keyHolder.numKeys; i++)
        {
            _Key key = (_Key)Marshal.PtrToStructure(ptr, typeof(_Key));
            Marshal.FreeHGlobal(key.keyName);
            ptr += Marshal.SizeOf(typeof(_Key));
        }
        Marshal.FreeHGlobal(keyHolder.keys);
    }
