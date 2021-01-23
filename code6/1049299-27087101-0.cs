  
    public override BaseMassage DeSerialize(byte[] data)
    {
            MemoryStream stream = new MemoryStream(data, 3, data.Length - 3);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.AssemblyFormat = System.Runtime.Serialization.Formatters.FormatterAssemblyStyle.Simple;
            formatter.Binder = new VersionConfigToNamespaceAssemblyObjectBinder();
            RadarMassage obj = (RadarMassage)formatter.Deserialize(stream);
            return obj;
    }
