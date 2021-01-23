    string str = "[jp3]TEST [fl]Flashing[/fl]";
    var bytes = Encoding.ASCII.GetBytes(str);
    Array.Resize(ref bytes, bytes.Length + 2);
    // Note that these two rows are useless, because the Array.Resize will have already filled with 0
    bytes[bytes.Length - 2] = 0; // dmsMessageBeacon
    bytes[bytes.Length - 1] = 0; // dmsMessagePixelService 
    ushort fcs2 = compute_fcs(bytes); // 0xF995
    var bytes2 = BitConverter.GetBytes(fcs2); // 0x95 0xF9
