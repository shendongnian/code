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
                //blstatus indicate whether instance is new or not
                string str = "Fashion Fades,Style Remains Same";
                Console.WriteLine("initial state");
                Console.WriteLine("str = {0}",str);
                Console.WriteLine("instance id : {0}",idGenerator.GetId(str,out blStatus));
                Console.WriteLine("this is new instance : {0}",blStatus);
                //a series of operations that won't change value of str
                str += "";
                //try to replace character 'x' which is not present in str so no change
                str = str.Replace('x','Q');
                //trim removes whitespaces from both ends so no change
                str = str.Trim();
                str = str.Trim();
                Console.WriteLine("\nfinal state");
                Console.WriteLine("str = {0}", str);
                Console.WriteLine("instance id : {0}", idGenerator.GetId(str, out blStatus));
                Console.WriteLine("this is new instance : {0}", blStatus);
                Console.ReadKey();
            }
        }
    }
