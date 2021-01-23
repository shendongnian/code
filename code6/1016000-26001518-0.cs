     List<byte> byteValues = new List<byte>();
     string split = "50573953463435464438414B58413135";
    
     for (int idx = 0; idx < split.Length - 1; idx += 2)
     {
         var value = split.Substring(idx, 2);
    
         byteValues.Add(Convert.ToByte(value, 16));
      }
    
      foreach (var b in byteValues)
           Console.WriteLine(b);
