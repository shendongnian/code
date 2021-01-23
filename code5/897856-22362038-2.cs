    // Chop up the string into individual hex values
    string[] hexStrings = hexString.Split(new[] { "\\x" }, StringSplitOptions.RemoveEmptyEntries);
    // Convert the individual hex strings into bytes
    byte[] bytes = hexStrings.Select(s => Convert.ToByte(s, 16)).ToArray();
    BitArray bitArray = new BitArray(bytes);
