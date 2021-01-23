    public static byte[] EncryptDecrypt(bool Encrypt, byte[] Source,
        int StartKey, int MultKey, int AddKey)
    {
        byte[] Dest = new byte[Source.Length];
        for (int i = 0; i < Source.Length; i++)
        {
            if (Encrypt)
            {
                unchecked
                {
                    Dest[i] = (byte) (Source[i] ^ (StartKey >> 8));
                    StartKey = (Dest[i] + StartKey) * MultKey + AddKey;
                }
            }
            else
            {
                unchecked
                {
                    Dest[i] = (byte) (Source[i] ^ (StartKey >> 8));
                    StartKey = (Source[i] + StartKey) * MultKey + AddKey;
                }
            }
        }
        return Dest;
    }
