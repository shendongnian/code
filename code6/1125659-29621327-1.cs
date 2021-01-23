    public static byte[,] State(byte[] Block)
    {
        var Nk = Block.Length / 4; //Assuming "Nk" is the row count.
        var State = new byte[Nk, 4];
        var i = 0;
        for (int row = 0; row < Nk; row++)
            for (int column = 0; column < 4; column++, i++)
                State[row, column] = Block[i];
        return State;
    }
