    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Net;
    using System.Net.Sockets;
    using System.Numerics;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("");
            long start = 0;
            long end = 99999999;
            long count = end - start + 1;
            long[] eans = new long[count];
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Parallel.For(start, end + 1, i => {
                eans[i] = GenerateEAN13(i);
            });
            sw.Stop();
            Console.WriteLine("Generation of {0} EAN-13s took {1} ticks ({2} ms)", count, sw.ElapsedTicks, sw.ElapsedMilliseconds);
            Console.ReadLine();
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long GenerateEAN13(long number)
        {
            long checksum = 0;
            long digit = 0;
            long tmp = number;
            for (int i = 13; i >= 0; i--)
            {
                digit = tmp % 10;
                tmp = tmp / 10;
                checksum += i % 2 == 0 ? digit * 3 : digit;
                if (tmp < 10)
                    break;
            }
            long modulus = checksum % 10;
            checksum = modulus == 0 ? 0 : 10 - modulus;
            return number * 10 + checksum;
        }
    }
