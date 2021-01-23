      // Encoding... 
      String source = "abc";
    
      // 011000010110001001100011
      String result = String.Join("", UTF8Encoding.UTF8.GetBytes(source).Select(x => ToBinary(x)));
      ... 
      // Decoding...
      List<Byte> codes = new List<Byte>();
      for (int i = 0; i < result.Length; i += 8) 
        codes.Add(FromBinary(result.Substring(i, 8)));
      // abc
      String sourceBack = UTF8Encoding.UTF8.GetString(codes.ToArray());
