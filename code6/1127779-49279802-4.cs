    public class TestClass 
    {
        public static void Test()
        {
            System.Collections.Generic.List<System.Guid> ls = new System.Collections.Generic.List<System.Guid>();
            for(int i = 0; i < 100; ++i)
                ls.Add(System.Guid.NewGuid());
            ls.Sort(Compare);
        }
        
        public static int Compare(System.Guid x, System.Guid y)
        {
            const int NUM_BYTES_IN_GUID = 16;
            byte byte1, byte2;
            byte[] xBytes = new byte[NUM_BYTES_IN_GUID];
            byte[] yBytes = new byte[NUM_BYTES_IN_GUID];
            x.ToByteArray().CopyTo(xBytes, 0);
            y.ToByteArray().CopyTo(yBytes, 0);
            int[] byteOrder = new int[16] // 16 Bytes = 128 Bit 
                {10, 11, 12, 13, 14, 15, 8, 9, 6, 7, 4, 5, 0, 1, 2, 3};
            //Swap to the correct order to be compared
            for (int i = 0; i < NUM_BYTES_IN_GUID; i++)
            {
                byte1 = xBytes[byteOrder[i]];
                byte2 = yBytes[byteOrder[i]];
                if (byte1 != byte2)
                    return (byte1 < byte2) ? -1 : 1;
            } // Next i 
            return 0;
        }
    }
