        bool c1 = true;  // checkbox1.Checked
        bool c2 = true;  // checkbox2.Checked
        bool c3 = false; // etc
        bool c4 = true;
        BitArray arr = new BitArray(new bool[4] { c1, c2, c3, c4 });
        byte[] bits = new byte[4];
        arr.CopyTo(bits, 0);
        int x = BitConverter.ToInt32(bits, 0);
