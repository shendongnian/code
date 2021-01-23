    private static IEnumerable<byte> ParseHex(string input) {
        for (int i = 0; i < input.Length; i += 2) 
    	    yield return Convert.ToByte(input.Substring(i, 2), 16);
    }
    public static void Main(string[] args) {
        string input = "6333526c595777675958646865513d3d";
        byte[] bytes = ParseHex(input).ToArray();
        string base64 = Encoding.ASCII.GetString(bytes);
        byte[] output = Convert.FromBase64String(base64);
        string outputString = Encoding.ASCII.GetString(output);
        Console.WriteLine(outputString);
    }
