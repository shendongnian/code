      short value = 12348;
      byte[] bytes = BitConverter.GetBytes(value);
      Console.WriteLine(BitConverter.ToString(bytes));
      if (BitConverter.IsLittleEndian)
         Array.Reverse(bytes);
      Console.WriteLine(BitConverter.ToString(bytes)); // write to your file
