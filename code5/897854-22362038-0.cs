    // Chop up the string into individual hex values
    string[] hexStrings = hexString.Split(new[] { "\\x" }, StringSplitOptions.RemoveEmptyEntries);
    // Convert the individual hex strings into integers
    int[] values = hexStrings.Select(s => Convert.ToInt32(s, 16)).ToArray();
    // Convert the integers into 8-character binary strings
    string[] binaryStrings = values.Select(v => Convert.ToString(v, 2).PadLeft(8, '0')).ToArray();
    // Join the strings together
    string binaryString = string.Join("", binaryStrings);
