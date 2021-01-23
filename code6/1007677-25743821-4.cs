    using System;
    using System.Diagnostics;
    namespace Demo
    {
        internal static class Program
        {
            static void Main()
            {
                byte[,,] source = new byte[100, 150, 3];
                for (int i = 0, n = 0; i < 100; ++i)
                    for (int j = 0; j < 150; ++j)
                        for (int k = 0; k < 3; ++k, ++n)
                            source[i, j, k] = unchecked ((byte)n);
                byte[,] dest1 = new byte[100, 150];
                byte[,] dest2 = new byte[100, 150];
                for (int i = 0; i < 100; ++i)
                    for (int j = 0; j < 150; ++j)
                        dest1[i, j] = source[i, j, 0];
                unsafe
                {
                    fixed (byte* sp = source)
                    fixed (byte* dp = dest2)
                    {
                        byte* q = dp;
                        byte* p = sp;
                        for (int i = 0; i < 100*150; ++i)
                        {
                            *q++ = *p;
                            p += 3;
                        }
                    }
                }
                for (int i = 0; i < 100; ++i)
                    for (int j = 0; j < 150; ++j)
                        Trace.Assert(dest1[i, j] == dest2[i, j], "Arrays should be identical");
            }
        }
    }
