    public void DoSomething()
    {
        var packet = new Packet();
        packet.PacketType = PacketTypes.INVALID; // Assign packtype
        Console.WriteLine(packet.PacketType.ToString()); // Retrieve and print 
    }
