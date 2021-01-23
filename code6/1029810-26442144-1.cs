    using System;
    
    class Test
    {
        static void Main()
        {
            long maxDoubleBits = BitConverter.DoubleToInt64Bits(Double.MaxValue);
            double nextLargestDouble = BitConverter.Int64BitsToDouble(maxDoubleBits - 1);
            double difference = double.MaxValue - nextLargestDouble;
            Console.WriteLine(difference);
        }
    }
