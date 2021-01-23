    string macAddress = "00:14:22:18:81:11";
    List<byte> packet = new List<byte>();
    packet.AddRange(new byte[] { 61, 7, 1 });
    packet.AddRange(macAddress.Split(':').Select(b => Convert.ToByte(b)));
    byte[] packetArrayBytes = packet.ToArray();
