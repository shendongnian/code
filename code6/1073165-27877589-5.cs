    const ushort DPC2_DATA_LEN_S = ..; // See SDK documentation and header file
    read_rb readRb = new read_rb();
    readRb.C_Ref = ..; // Set identifier for connection.
    readRb.Slot_Number = ..; // Set required slot on destination device.
    readRb.Index = ..; // Set the index parameter.
    // Set the length field to at least DPC2_DATA_LEN_S
    // See SDK documentation for more information.
    readRb.Length_s = DPC2_DATA_LEN_S; 
    try
    {
      // Allocate memory for data pointer.
      readRb.Data_s = Marshal.AllocHGlobal(DPC2_DATA_LEN_S);
      // Call the read function
      ushort result = read(ref readRb);
      // Check return value here.
      if (result != ../*DPC2_OK*/)
      {
        // Handle error case
      }
      else
      {
         // Use Marshal.Copy to copy the received 
         // data to a byte buffer.
         byte[] buffer = new byte[DPC2_DATA_LEN_S];
         Marshal.Copy(readRb.Data_s, buffer, 0, buffer.Length);
         // Do something with data ...
      }
    }
    finally
    {
      // Finally, release the allocated memory.
      if(readRb.Data_s !+ IntPtr.Zero)
      {
        Marshal.FreeHGlobal(readRb.Data_s);
      }
    }
