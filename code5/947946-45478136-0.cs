        public static string ToBinary(int myValue)
        {
            string binVal = Convert.ToString(myValue, 2);
            int bits = 0;
            int bitblock = 4;
            for (int i = 0; i < binVal.Length; i = i + bitblock)
            { bits += bitblock; }
            return binVal.PadLeft(bits, '0');
        }
