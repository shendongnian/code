    public static byte[,] State(byte[] Block)
    {
        if (Block.Length % 16 != 0)
            throw new Exception("Byte array length must be divisible by 16.");
        var rowCount = Block.Length / 4;
        var State = new byte[rowCount, 4];
        for (int column = 0, block = 0; column < 4; column++)
            for (int row = 0; row < rowCount; row++, block++)
                State[row, column] = Block[block];
        return State;
    }
