    class Program
    {
        static int ITERATIONS = 100000;
        static void Main(string[] args)
        {
            var pass_packet = Enumerable.Range(0, 1024).Select(i => (byte)i).ToArray();
    
            int local_index = 5;
    
            var sw = Stopwatch.StartNew();
            var result = StringBuilderTEST(pass_packet, local_index);
    
            Console.WriteLine(result + " in {0}ms", sw.ElapsedMilliseconds);
    
            //second option
            sw.Restart();
            var result2 = ArrayReversalTEST(pass_packet, local_index);
            Console.WriteLine(result2 + " in {0}ms", sw.ElapsedMilliseconds);
    
            sw.Restart();
            var result3 = ArrayReversal2TEST(pass_packet, local_index);
            Console.WriteLine(result3 + " in {0}ms", sw.ElapsedMilliseconds);
    
            sw.Restart();
            var result4 = StupidlyFastTEST(pass_packet, local_index);
            Console.WriteLine(result4 + " in {0}ms", sw.ElapsedMilliseconds);
    
            Console.WriteLine("Results are equal?  " + (result == result2 && result == result3 && result == result4));
            Console.ReadLine();
        }
    
        private static string StringBuilderTEST(byte[] pass_packet, int local_index)
        {
            string result = null;
            for (int b = 0; b < ITERATIONS; b++)
            {
                var sb = new StringBuilder();
                for (int i = 511; i >= 400; i--)
                    sb.Append(BitConverter.ToString(pass_packet, local_index + i, 1));
                result = sb.ToString();
            }
            return result;
        }
    
        private static string ArrayReversalTEST(byte[] pass_packet, int local_index)
        {
            string result = null;
            for (int b = 0; b < ITERATIONS; b++)
            {
                var selectedData = pass_packet.Skip(400 + local_index).Take(112).Reverse().ToArray();
                result = BitConverter.ToString(selectedData).Replace("-", "");
            }
            return result;
        }
    
        private static string ArrayReversal2TEST(byte[] pass_packet, int local_index)
        {
            string result = null;
            for (int b = 0; b < ITERATIONS; b++)
            {
                var tempArray = new byte[112];
                Array.Copy(pass_packet, 400 + local_index, tempArray, 0, 112);
                Array.Reverse(tempArray);
                result = BitConverter.ToString(tempArray).Replace("-", "");
            }
            return result;
        }
    
        private static string StupidlyFastTEST(byte[] pass_packet, int local_index)
        {
            string result = null;
            string hex = "0123456789ABCDEF";
            for (int it = 0; it < ITERATIONS; it++)
            {
                var tempArray = new char[112 * 2];
                int tempArrayIndex = 0;
                for (int i = 511; i >= 400; i--)
                {
                    var b = pass_packet[local_index + i];
                    tempArray[tempArrayIndex++] = hex[b / 16];
                    tempArray[tempArrayIndex++] = hex[b % 16];
                }
                result = new string(tempArray);
            }
            return result;
        }
    }
