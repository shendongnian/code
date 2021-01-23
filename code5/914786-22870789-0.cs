    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var insertInPos = 1;
                var inBytes = new byte[] {01 ,02 ,03, 04, 05, 06, 07, 08, 09, 0x0A };
                var insertBytes = new byte[] {0xFF, 0xDD};
                var newBytes = InsertBytes(inBytes, insertBytes, insertInPos);
            }
            public static byte[] InsertBytes(byte[] inBytes, byte[] insertBytes, int insertInPos)
            {
                var insertLen = insertBytes.Length - 1;
                var outBytes = new byte[inBytes.Length + insertLen + 1];
                var outLen = outBytes.Length - 1;
                for (int i = 0, j = 0; i < outLen; ++i)
                {
                    if (i < insertInPos)
                    {
                        outBytes[i] = inBytes[i];
                    }
                    else if (i == insertInPos)
                    {
                        while (j <= insertLen)
                        {
                            outBytes[i + j] = insertBytes[j++];
                        }
                    }
                    else
                    {
                        outBytes[i + insertLen] = inBytes[i - insertLen];
                    }
                }
                return outBytes;
            }
        }
    }
