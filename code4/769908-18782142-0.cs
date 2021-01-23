    using (var output = File.Create(outputPath))
    {
        foreach (var file in Directory.GetFiles(InputPath,temp_file_format))
        {
            using (var input = File.OpenRead(file))
            {
                input.CopyTo(output);
            }
        }
    }
