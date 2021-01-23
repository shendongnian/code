    void Main()
    {
    	byte[] arr = { 0, 48, 136, 21, 69, 131, 0, 24, 231, 253, 174, 161, 8, 0, 69, 0, 0, 52, 2, 31, 64, 0, 128, 6, 230, 22, 212, 25, 99, 74, 202, 177, 16, 121, 194, 156, 0, 119, 160, 128, 75, 200, 249, 141, 210, 78, 80, 24, 64, 252, 130, 182, 0, 0, 65, 82, 84, 73, 67, 76, 69, 32, 51, 52, 13, 10 };
    	var stream = new MemoryStream(arr, 0, arr.Length);
        var reader = new BinaryReader(stream);
    
    	Print("Version and header length", reader.ReadByte());
    	Print("Diff services", reader.ReadByte());
    	
    	Print("Total length", IPAddress.NetworkToHostOrder(reader.ReadInt16())); 
    	Print("ID", IPAddress.NetworkToHostOrder(reader.ReadInt16()));
    	Print("Flags and offset", IPAddress.NetworkToHostOrder(reader.ReadInt16()));
    	
    	Print("TTL", reader.ReadByte());
    	Print("Protocol", reader.ReadByte());
    	Print("Checksum", reader.ReadInt16());
    	
    	Print("Source IP", new IPAddress((int) reader.ReadInt32()));
    	Print("Destination IP", new IPAddress((int) reader.ReadInt32()));
    }
