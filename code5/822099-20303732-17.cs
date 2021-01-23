    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Diagnostics;
    using System.Text;
    namespace ConsoleApplication1
    {
    class Program
    {
    static void Main(string[] args)
    {
        /* Used http://stackoverflow.com/a/20285267/40868 as a template */
        var random = new Random(42); //used a constant to keep result consistant
        var skeleton = new StringBuilder();
        var replaceWhat = "BC";
        var replaceIterations = new List<string>();
        for (var i = 0; i < Math.Pow(10, 6) / 2; i++)
        {
            var randomNumber = random.Next(0, 3);
            var character = randomNumber == 0 ? 'A' : randomNumber == 1 ? 'B' : 'C';
            skeleton.Append(character);
        }
        for (var i = 0; i < 500; i++)
        {
            var randomNumber = random.Next(0, 3);
            var replaceIteration = randomNumber == 0 ? "AB" : randomNumber == 1 ? "BC" : "CD";
            replaceIterations.Add(replaceIteration);
        }
        /* end of template */
        var input = skeleton.ToString();
        var replace = replaceWhat;
        var replaceBy = replaceIterations.ToArray();
        var inputLength = input.Length;
        TestFredou(input, inputLength, replace, replaceBy, false);
        TestFredou(input, inputLength, replace, replaceBy, true);
        Console.ReadKey();
    }
    private unsafe static void TestFredou(string input, int inputLength, string replace, string[] replaceBy, bool useTestingValue)
    {
        string[] output;
        if (useTestingValue)
        {
            input = "ABCDABCABCDABCABCDABCABCDABCD";
            replace = "BC";
            replaceBy = new string[] { "AA", "BB", "CC", "DD", "EE" };
            inputLength = input.Length;
            output = new string[replaceBy.Length];
            for (int i = 0; i < replaceBy.Length; ++i)
            {
                output[i] = string.Copy(input);
            }
            Parallel.For(0, replaceBy.Length, l => Process(output[l], input, inputLength, replace, replaceBy[l]));
            Console.WriteLine("\nQuality Control");
            Console.WriteLine("Input : {0} - replace {1} by {2}", input, replace, string.Join(",", replaceBy));
            for (int i = 0; i < replaceBy.Length; ++i)
            {
                Console.WriteLine("Output: {0} - valid {1}", output[i], output[i] == input.Replace(replace, replaceBy[i]));
            }
        }
        else
        {
            output = new string[replaceBy.Length];
            for (int i = 0; i < replaceBy.Length; ++i)
            {
                output[i] = string.Copy(input);
            }
            for (int i = 1; i < 6; ++i)
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
                var stopWatch = Stopwatch.StartNew();
                Parallel.For(0, replaceBy.Length, l => Process(output[l], input, inputLength, replace, replaceBy[l]));
                stopWatch.Stop();
                Console.WriteLine("#{1} fredou implementation - {0} milliseconds", stopWatch.ElapsedMilliseconds, i);
            }
        }
    }
    private unsafe static void Process(string ouput, string input, int len, string replace, string replaceBy)
    {
        fixed (char* o = ouput, i = input, r = replace)
        {
            while (len > -1)
            {
                if (len > 0 && i[len] == r[1] && i[len-1] == r[0])
                {
                    o[len] = replaceBy[0]; o[--len] = replaceBy[1];
                }
                --len;
            }
        }
    }
    }
    }
