    var result = Regex.Split(file, "\r\n|\r|\n");
    foreach (string op in result)
    {
        string[] splitop = Regex.Split(op, "=");
        RecvOpcodes.Add(new Opcode(splitop[0], Convert.ToInt16(splitop[1], 16))); // splitop[0] will contain Test, Stack and Recv; splitop[1] will contain 0x01, 0x03, 0x0B
    }
