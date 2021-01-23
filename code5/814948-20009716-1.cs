    byte[] fileBytes = File.ReadAllBytes(inputFilename);
    StringBuilder sb = new StringBuilder();
    foreach(byte b in fileBytes)
    {
        sb.Append(Convert.ToString(b, 2).PadLeft(8, '0'));  // adds 8 '0's to left of the string
    }
    File.WriteAllText(outputFilename, sb.ToString());
