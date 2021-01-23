    // requires following assembly references:
    //
    //using System.Xml;
    //using System.IO;
    //using System.Runtime.Serialization;
    //using System.Runtime.Serialization.Formatters.Binary;
    //
    // Target object “obj”
    //
    long length = 0;
    
    MemoryStream stream1 = new MemoryStream();
    using (XmlDictionaryWriter writer = 
        XmlDictionaryWriter.CreateBinaryWriter(stream1))
    {
        NetDataContractSerializer serializer = new NetDataContractSerializer();
        serializer.WriteObject(writer, obj);
        length = stream1.Length; 
    }
    
    if (length == 0)
    {
        MemoryStream stream2 = new MemoryStream();
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(stream2, obj);
        length = stream2.Length;
    }
    // do somehting with length
