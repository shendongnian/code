    using System;
    using System.Text;
    class UTF8EncodingExample {
    public static void Main() {
        // Create a UTF-8 encoding.
        UTF8Encoding utf8 = new UTF8Encoding();
        // A Unicode string with two characters outside an 8-bit code range.
        String unicodeString =
            "This unicode string contains two characters " +
            "with codes outside an 8-bit code range, " +
            "Pi (\u03a0) and Sigma (\u03a3).";
        Console.WriteLine("Original string:");
        Console.WriteLine(unicodeString);
        // Encode the string.
        Byte[] encodedBytes = utf8.GetBytes(unicodeString);
        Console.WriteLine();
        Console.WriteLine("Encoded bytes:");
        foreach (Byte b in encodedBytes) {
            Console.Write("[{0}]", b);
        }
        Console.WriteLine();
        // Decode bytes back to string. 
        // Notice Pi and Sigma characters are still present.
        String decodedString = utf8.GetString(encodedBytes);
        Console.WriteLine();
        Console.WriteLine("Decoded bytes:");
        Console.WriteLine(decodedString);
    }}
