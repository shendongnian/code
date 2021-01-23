    string auth = "1"; // example data, would come from your object
    string key0 = "2";
    
    byte[] local1;
    using (MemoryStream m = new MemoryStream()) {
      using (BinaryWriter w = new BinaryWriter(m)) {
        w.Write(Int32.Parse(auth));
        w.Write(Int32.Parse(key0));
      }
      local1 = m.ToArray(); 
