    void ConvertToHex(string inputFilePath, string outputFilePath)
    {
        var bytes = File.ReadAllBytes(inputFilePath);
        var hexString = string.Join("", bytes.Select(x => x.ToString("X2")));
        File.WriteAllText(outputFilePath, hexString);
    }
