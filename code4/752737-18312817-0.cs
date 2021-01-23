    public static byte[] ConvertHexString(string hex)
    { 
      Contract.Requried(!string.IsNullOrEmpty(hex));
      // get length
      var len = hex.Length;
      if (len % 2 == 1)
      {
        throw new ArgumentException("hexValue: " + hex);
      }
      var lenHalf = len / 2;
      // create a byte array
      var bs = new byte[lenHalf];
      try
      {
        // convert the hex string to bytes
        for (var i = 0; i != lenHalf; i++)
        {
          bs[i] = (byte)int.Parse(hex.Substring(i * 2, 2), NumberStyles.HexNumber, CultureInfo.InvariantCulture);
        }
      }
      catch (Exception ex)
      {
        throw new ParseException(ex.Message, ex);
      }
      // return the byte array
      return bs;
    }
