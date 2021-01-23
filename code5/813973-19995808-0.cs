    public static Int16 Get16BitHash2(string s)
    {
        using (var md5Hasher = MD5.Create())
        {
            var data = md5Hasher.ComputeHash(Encoding.UTF8.GetBytes(s));
            return BitConverter.ToInt16(data, 0);
        }
    }
