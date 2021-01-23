        MemoryStream bufferStream = new MemoryStream();
        BinaryWriter writer = new BinaryWriter(bufferStream);
        writer.Write(new byte[] { 0xAA, 0x55, 0x01 });
        writer.Write((ushort)66 + 8); // size of username/password, plus all overheads
        writer.Write((byte) 0x01);
        writer.Write("foouser".PadRight(33, '\0')) // Padding to 33 characters
        writer.Write("foooassword".PadRight(33, '\0')) // Padding to 33 characters
        // calculate CRC
        ushort crc16 = 999;
        writer.Write(crc16);
        // get result
        byte[] result = bufferStream.ToArray();
