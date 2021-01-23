    public static string MyHMACHash(string key, string message)
    {
        Encoding encoding = Encoding.UTF8;
    
        //Reference http://en.wikipedia.org/wiki/Secure_Hash_Algorithm
        //SHA256 block size is 512 bits => 64 bytes.
        const int HashBlockSize = 64;
    
        var keyBytes = encoding.GetBytes(key);
        var opadKeySet = new byte[HashBlockSize];
        var ipadKeySet = new byte[HashBlockSize];
    
                
        if (keyBytes.Length > HashBlockSize)
        {
            keyBytes = GetHash(keyBytes);
        }
                
        // This condition is independent of previous
        // condition. If previous was true
        // we still need to execute this to make keyBytes same length
        // as blocksize with 0 padded if its less than block size
        if (keyBytes.Length < HashBlockSize)
        {
            var newKeyBytes = new byte[HashBlockSize];
            keyBytes.CopyTo(newKeyBytes, 0);
            keyBytes = newKeyBytes;
        }
    
                
        for (int i = 0; i < keyBytes.Length; i++)
        {
            opadKeySet[i] = (byte)(keyBytes[i] ^ 0x5C);
            ipadKeySet[i] = (byte)(keyBytes[i] ^ 0x36);
        }
    
        var hash = GetHash(ByteConcat(opadKeySet, 
            GetHash(ByteConcat(ipadKeySet, encoding.GetBytes(message)))));
    
        // Convert to standard hex string 
        return hash.Select<byte, string>(a => a.ToString("x2"))
                    .Aggregate<string>((a, b) => string.Format("{0}{1}", a, b));            
    }
    
    public static byte[] GetHash(byte[] bytes)
    {
        using (var hash = new SHA256Managed())
        {
            return hash.ComputeHash(bytes);
        }
    }
    
    public static byte[] ByteConcat(byte[] left, byte[] right)
    {
        if (null == left)
        {
            return right;
        }
    
        if (null == right)
        {
            return left;
        }
    
        byte[] newBytes = new byte[left.Length + right.Length];
        left.CopyTo(newBytes, 0);
        right.CopyTo(newBytes, left.Length);
    
        return newBytes;
    }
