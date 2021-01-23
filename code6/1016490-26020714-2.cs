    try
    {             
        using (Stream resourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Namespacename.service.exe"))
      {
          using (FileStream fileStream = new FileStream(@"c:\service.exe", System.IO.FileMode.Create))
          {
              for (int i = 0; i < resourceStream.Length; i++)
                  fileStream.WriteByte((byte)resourceStream.ReadByte());
           }
        }
     }
     catch
     {
         // ToDo
     }
