    public Stream ZipObject(Stream data)
    {
        var output = new MemoryStream();
        using (var zip = new ZipFile())
        {
            zip.AddEntry(Name, data);
            zip.Save(output);
        }
        output.Position = 0;
        return output;
    }
