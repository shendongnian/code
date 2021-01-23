    string original = "XZJ6RTNN4NNNNNNR8YWWX7ZGWO1XXQT6PSRT5281I0WQZM75K2P3SPH81XN4M3L1WF6Q";
    Console.WriteLine("Original #characters = " + original.Length + " characters, or byte count = " + 2*original.Length);
    byte[] compressed = Convert.FromBase64String(original);
    Console.WriteLine("Compressed length = " + compressed.Length);
    string decompressed = Convert.ToBase64String(compressed);
    if (decompressed == original)
        Console.WriteLine("Decompressed OK");
    else
        Console.WriteLine("Failed to decompress!");
