    byte[] test = new byte[1000000];
    for (int i = 0; i < 256; i++)
    {
        test[i] = (byte)i;
    }
    var ciphertext = Encrypt(Encoding.Default.GetString(test), "0000000000000000", "0000000000000000");
    byte[] check = Decrypt(ciphertext, "0000000000000000", "0000000000000000");
    for (int i = 0; i < 256; i++)
    {
        Debug.Assert(check[i] == (byte)i, "round trip");
    }
