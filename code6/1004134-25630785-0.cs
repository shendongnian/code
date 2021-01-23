        int iHex = 0x42F4;
        int iResult = 0;
        UInt16[] bits = new UInt16[16] {0x8, 0x800, 0x4, 0x400, 0x2, 0x200, 0x1, 0x100,
                                  0x1000, 0x10, 0x2000, 0x20, 0x4000, 0x40, 0x8000, 0x80};
        for (int i = 0; i < 16; i++)
        {
            if ((iHex & 1) == 1)
                  iResult += bits[i];
            iHex >>= 1;
        }
        MessageBox.Show("0x" + iResult.ToString("X"));
        // Output: 0x8317
