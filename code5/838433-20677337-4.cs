    var bytes = new List<byte>();
    for (int i = 0; i < strData.Length; i+=2)
    {
        bytes.Add(Byte.Parse(strData[i].ToString() + strData[i+1].ToString(),
           NumberStyles.HexNumber));
    }
    File.WriteAllBytes("C:\\path\\to\\file.bin", bytes.ToArray());
