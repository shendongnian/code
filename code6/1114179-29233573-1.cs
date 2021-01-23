    string cFilename = "";
    if (GV.ByteSymbolMann == null) // not yet loaded
    {
      cFilename = GV.cEmbeddedAblage + "SymbolMann.jpg";
      var assembly = this.GetType().GetTypeInfo().Assembly; 
      byte[] buffer;
      using (Stream s = assembly.GetManifestResourceStream(cFilename))
       {
         long length = s.Length;
         buffer = new byte[length];
         s.Read(buffer, 0, (int)length);
         GV.ByteSymbolMann = buffer; // Overtake byte-array in global variable for male
       }
    }
    //
    if (GV.ByteSymbolFrau == null) // not yet loaded
    {
      cFilename = GV.cEmbeddedAblage + "SymbolFrau.jpg";
      var assembly = this.GetType().GetTypeInfo().Assembly; 
      byte[] buffer;
      using (Stream s = assembly.GetManifestResourceStream(cFilename))
       {
         long length = s.Length;
         buffer = new byte[length];
         s.Read(buffer, 0, (int)length);
         GV.ByteSymbolFrau = buffer; // Overtake byte-array in global variable for female
        }
    }
