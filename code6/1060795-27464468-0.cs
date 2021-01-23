	private static UTF8Encoding utf8 = new UTF8Encoding(false, true);
	public static string BinaryToString(string data) {
        List<Byte> byteList = new List<Byte>();
        for (int i = 0; i < data.Length; i += 8) {
            byteList.Add(Convert.ToByte(data.Substring(i, 8), 2));
        }
        return utf8.GetString(byteList.ToArray());
	}
