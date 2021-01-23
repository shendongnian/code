    string str = "0111001101101000";
    int numOfBytes = str.Length / 8;
    byte[] bytes = new byte[numOfBytes];
    for (int i = 0; i < numOfBytes; ++i)
    {
        bytes[i] = Convert.ToByte(str.Substring(8 * i, 8), 2);
    }
    string output = Encoding.UTF8.GetString(bytes);     
