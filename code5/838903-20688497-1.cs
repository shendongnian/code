    private byte[] MakeByteSize<U>(U obj)
    {
      if (obj == null) return null;
	
      var bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
      var ms = new System.IO.MemoryStream();
      bf.Serialize(ms, obj);
	
      return ms.ToArray();
    }
