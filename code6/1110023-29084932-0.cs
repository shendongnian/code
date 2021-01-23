    public byte[] ArrayJoin(byte separator, List<byte[]> arrays)
    {
        using (MemoryStream result = new MemoryStream())
        {
            byte[] first = arrays.First();
            result.Write(first, 0, first.Length);
            foreach (var array in arrays.Skip(1))
            {
                result.WriteByte(separator);
                result.Write(array, 0, array.Length);
            }
            return result.ToArray();
        }
    }
