    public static Tuple<FileInfo, string> GenerateMapInfo(string mapDirectory, string fileExtension)
    {
        var uniqueMapName = Guid.NewGuid().ToString();
        var fileName = Path.Combine(mapDirectory, Path.ChangeExtension(uniqueMapName, fileExtension));
        return Tuple.Create(new FileInfo(fileName), uniqueMapName);
    }
    public void WriteToFile(Tuple<FileInfo, string> mapInfo, string value)
    {
        byte[] newValue = Encoding.UTF8.GetBytes(value);
        long capacity = newValue.Length + INT_MAXVALUE_TO_BYTEARRAY_LENGTH;
        using (var mmf = MemoryMappedFile.CreateFromFile(mapInfo.Item1.FullName, FileMode.Create, mapInfo.Item2, capacity))
        using (var accesor = mmf.CreateViewAccessor())
        {
            byte[] newValueLength = BitConverter.GetBytes(value.Length);
            accesor.WriteArray(0, newValueLength, 0, newValueLength.Length);
            accesor.WriteArray(INT_MAXVALUE_TO_BYTEARRAY_LENGTH, newValue, 0, newValue.Length);
        }
    }
