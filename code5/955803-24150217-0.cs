    using (var output = File.OpenWrite(mainFileName))
    {
        foreach (string currentFile in filesToAppend)
        {
            using (var input = File.OpenRead(currentFile))
            {
                input.CopyTo(output);
            }
        }
    }
