         static void Main(string[] args)
        {
            byte byte1 = 255;
            byte byte2 = 255;
            for (var i = 0; i <= 7; i++)
            {
                if ((byte1 & (1 << i)) == (byte2 & (1 << i)))
                {
                    // position i in byte1 is the same as position i in byte2
                    // clear bit that is the same in both numbers
                    ClearBit(ref byte1, i);
                    ClearBit(ref byte2, i);
                }
                else
                {
                    // if not the same.. do something here
                }
                Console.WriteLine(Convert.ToString(byte1, 2).PadLeft(8, '0'));
            }
            Console.ReadKey();
        }
        private static void ClearBit(ref byte value, int position)
        {
            value = (byte)(value & ~(1 << position));
        }
    }
