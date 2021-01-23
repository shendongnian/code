    public Stream MySVC(string stringP)
    {
        var mem = new MemoryStream();
        var ser = new DataContractJsonSerializer(typeof(string));
        ser.WriteObject(mem, stringP);
        mem.Seek(0, SeekOrigin.Begin);
        return mem;
    }
