    private Byte[] ToByteArray(Atring stringToConvert)
    {
        Contract.Requires(stringToConvert.Length % 8 == 0);
        
        var result = new Byte[stringToConvert.Length / 8];
        for (var index = 0; index < stringToConvert.Length / 8; index++)
        {
          result[index] = Convert.ToByte(stringToConvert.Substring(index * 8, 8), 2);
        }
        return result;
    }
