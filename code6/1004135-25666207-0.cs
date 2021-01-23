        private UInt16 Decode(UInt16 iHex)
        {
            UInt16[] bits = new UInt16[16] {0x40, 0x800, 0x4, 0x1, 0x200, 0x800, 0x2000, 0x8000,
                  0x80, 0x20, 0x8, 0x2, 0x100, 0x400, 0x1000, 0x4000};
            for (int i = 0; iHex != 0; iHex >>= 1, i++)
            {
                if ((iHex & 1) == 1)
                    iResult += bits[i];
            }
            return iResult;
        }
