    using System;
    using System.Text;
    using System.Runtime.Serialization;
    namespace StringVsStringBuilder
    {
        class Program
        {
            static void Main(string[] args)
            {
                ObjectIDGenerator idGenerator = new ObjectIDGenerator();
                bool blStatus = new bool();
                // blStatus indicates whether the instance is new or not
                string str = "Fashion Fades,Style Remains Same";
                Console.WriteLine("Initial state");
                Console.WriteLine("str = {0}", str);
                Console.WriteLine("Instance id: {0}", idGenerator.GetId(str, out blStatus));
                Console.WriteLine("This is new instance: {0}", blStatus);
                // A series of operations that won't change value of str
                str += "";
                // Try to replace character 'x' which is not present in str so no change
                str = str.Replace('x', 'Q');
                // Trim removes whitespaces from both ends so no change
                str = str.Trim();
                str = str.Trim();
                Console.WriteLine("\nFinal state");
                Console.WriteLine("str = {0}", str);
                Console.WriteLine("Instance id: {0}", idGenerator.GetId(str, out blStatus));
                Console.WriteLine("This is new instance: {0}", blStatus);
                Console.ReadKey();
            }
        }
    }
