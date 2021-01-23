    static byte[] GetBytes(string str)
    {
        byte[] bytes = new byte[str.Length * sizeof(char)];
        System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
        return bytes;
    }
    RegistryKey rk = Registry.CurrentUser.CreateSubKey("RegistryValueKindExample");
    rk.SetValue("BinaryValue", GetBytes("12968"), RegistryValueKind.Binary);
