    static byte[] GetBytes(string str) {
        byte[] bytes = Encoding.UTF8.GetBytes(str);
        // System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
        Console.WriteLine("Base64 debug: " + Convert.ToBase64String(data));
        return bytes;
    }
