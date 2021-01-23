    public static string BinaryToString(string data)
    {
    List<Byte> byteList = new List<Byte>();
 
    for (int i = 0; i < data.Length; i += 8)
    {
     byteList.Add(Convert.ToByte(data.Substring(i, 8), 2));
    }
 
    return Encoding.ASCII.GetString(byteList.ToArray());
    }
