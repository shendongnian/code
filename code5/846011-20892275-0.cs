    static uint MakeIPAddressInt32(byte[] array)
    {
      // Make a defensive copy.
      var ipBytes = new byte[array.Length];
      array.CopyTo(ipBytes, 0);
    
      // Reverse if we are on a little endian architecture.
      if(BitConverter.IsLittleEndian)
        Array.Reverse(ipBytes);
    
      // Convert these bytes to an unsigned 32-bit integer (IPv4 address).
      return BitConverter.ToUInt32(ipBytes, 0);
    } 
