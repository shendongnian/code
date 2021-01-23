    System.IO.MemoryStream stream = new System.IO.MemoryStream(); 
    System.Runtime.Serialization.IFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
    formatter.Serialize(stream, dtUsers); // dtUsers is a DataTable
    
    byte[] bytes = stream.GetBuffer();
