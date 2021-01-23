    public static async Task DecompressGZip(string inputPath, string outputPath)
    {
        using (var input = File.OpenRead(inputPath))
        using (var output = File.OpenWrite(outputPath))
        using (var gz = new GZipStream(input, CompressionMode.Decompress))
        {
            await gz.CopyToAsync(output);
        }
    }
