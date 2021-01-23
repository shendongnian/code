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
    
        Console.WriteLine("Results are equal?  " + result == result2);
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
