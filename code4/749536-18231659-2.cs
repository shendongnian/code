    var packet = new byte[]{
        97, 108, 101, 120, 0, 0, 0, 0, 0, 0, 0, 0, // username
        112, 97, 115, 115, 119, 111, 114, 100, 0, 0, 0, 0, //password
        49, 50, 51, 0, // id_number
        0, 53, 0, 0, 1, // 1st data packet
        0, 54, 1, 2, 5, 2, // 2nd data packet
        49, 0 // crc
    };
    var username = Encoding.ASCII.GetString(packet.Take(12).ToArray());
    var password = Encoding.ASCII.GetString(packet.Skip(12).Take(12).ToArray());
    var idNumber = Encoding.ASCII.GetString(packet.Skip(24).Take(4).ToArray());
    var data = packet.Skip(28).Take(packet.Length - 30).ToArray();
    var crc = Encoding.ASCII.GetString(packet.Skip(packet.Length - 2).ToArray());
    var nextDataPackedPos = 0;
    var nextDataPackedPos = 0;
    var dataPackets = data
        .TakeWhile(b => nextDataPackedPos < data.Length)
        .Zip(data.Skip(nextDataPackedPos), (a, b) =>
        {
            var size = Int32.Parse(
            Encoding.ASCII
                .GetString(data.Skip(nextDataPackedPos).Take(2).ToArray())
                .Trim('\0')
            );
            var result = data.Skip(nextDataPackedPos).Take(size).ToArray();
            nextDataPackedPos += size;
            return result;
        }).ToList();
