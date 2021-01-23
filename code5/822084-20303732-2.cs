    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    namespace ConsoleApplication1
    {
    class Program
    {
        static void Main(string[] args)
        {
            var input =  "ABCDABCABCDABCABCDABCABCDABCD";
            var replace = "BC".ToCharArray();
            var replaceBy = new string[] { "AA", "BB", "CC", "DD", "EE" };
            Fredou(input, replace, replaceBy);
            Console.ReadKey();
        }
        private static void Fredou(string input, char[] replace, string[] replaceBy)
        {
            var output = new List<char[]>();
            var inputLength = input.Length;
            for (int i = 0; i < replaceBy.Length; ++i)
            {
                output.Add(new char[inputLength]);
            }
            Parallel.For(replaceBy.GetLowerBound(0), replaceBy.Length, i =>
            {
                for (int j = 0; j < inputLength; ++j)
                {
                    if ((j + 1) <= input.Length && input[j] == replace[0] && input[j + 1] == replace[1])
                    {
                        output[i][j] = replaceBy[i][0];
                        output[i][++j] = replaceBy[i][1];
                    }
                    else
                    {
                        output[i][j] = input[j];
                    }
                }
            });
            foreach (var s in output)
            {
                Console.WriteLine(s);
            }
            
            Console.WriteLine(new string(output[0]) == "AAADAAAAAADAAAAAADAAAAAADAAAD");
            Console.WriteLine(new string(output[1]) =="ABBDABBABBDABBABBDABBABBDABBD");
            Console.WriteLine(new string(output[2]) =="ACCDACCACCDACCACCDACCACCDACCD");
            Console.WriteLine(new string(output[3]) =="ADDDADDADDDADDADDDADDADDDADDD");
            Console.WriteLine(new string(output[4]) == "AEEDAEEAEEDAEEAEEDAEEAEEDAEED");
        }
    }
    }
