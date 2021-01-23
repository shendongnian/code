    static string hexConverter(string hexString)
    {
      return Encoding.ASCII.GetString(fetchBytes(hexString).ToArray());
    }
    
    static IEnumerable<byte> fetchBytes(String hexString)
    {
      foreach (var value in hexString.Split('-'))
        yield return byte.Parse(value, System.Globalization.NumberStyles.HexNumber);
    }
