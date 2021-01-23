    string newLineText = "Here's the new line";
    using (var writer = new StreamWriter(outputFileName))
    using (var reader = File.OpenRead(inputFileName))
    {
        writer.WriteLine(newLineText);
        reader.CopyTo(writer.BaseStream);
    }
