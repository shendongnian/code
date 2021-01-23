    public static void Test()
    {
        var container = new CompositionContainer(new DirectoryCatalog(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)));
        var packets = container.GetExportedValues<IPacket>().ToArray();
        var packetSurrogateProviders = container.GetExportedValues<IPacketSurrogateProvider>();
        var surrogateSelector = new SurrogateSelector();
        foreach (var provider in packetSurrogateProviders)
        {
            provider.AddSurrogate(surrogateSelector);
        }
        var deserializedPackets = new IPacket[] { };
        using (var stream = new MemoryStream())
        {
            var formatter = new BinaryFormatter {SurrogateSelector = surrogateSelector};
            formatter.Serialize(stream, packets);
            stream.Position = 0;
            deserializedPackets = (IPacket[])formatter.Deserialize(stream);
        }
        foreach (var packet in deserializedPackets)
        {
            Console.WriteLine("Packet info: {0}", packet.GetInfo());
        }
    }
