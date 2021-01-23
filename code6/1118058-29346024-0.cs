    static void Main(string[] args)
    {
        string input = "This is an example text.";
    
        Console.WriteLine(input);
        string asBin = ToBinary(input);
        Console.WriteLine(asBin);
        string asText = ToText(asBin);
        Console.WriteLine(asText);
    }
    
    static string ToBinary(string input, System.Text.Encoding encoding = null)
    {
        if (encoding == null)
            encoding = System.Text.Encoding.UTF8;
    
        var builder = new System.Text.StringBuilder();
        var bytes = encoding.GetBytes(input); // Convert the text to bytes using the encoding
    
        foreach (var b in bytes)
            builder.Append(Convert.ToString(b, 2).PadLeft(8, '0')); //Convert the byte to its binary representation
    
        return builder.ToString();
    }
    
    static string ToText(string bytes, System.Text.Encoding encoding = null)
    {
        if (encoding == null)
            encoding = System.Text.Encoding.UTF8;
    
        var byteCount = 8;
        var byteArray = new byte[bytes.Length / 8]; // An array for the bytes
        for (int i = 0; i < bytes.Length / byteCount; i++)
        {
            var subBytes = bytes.Substring(i * byteCount, byteCount); // Get a subpart of 8 bits
            var b = Convert.ToByte(subBytes.TrimStart('0'), 2); // Convert the subpart to a byte
            byteArray[i] = b; // Add the byte to the array
        }
    
        return encoding.GetString(byteArray); // Convert the array to text using the right encoding.
    }
