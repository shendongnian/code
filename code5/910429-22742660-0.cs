    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace RND
    {
    class Program
    {
        static void Main(string[] args)
        {
            zahra();
        }
        public static void zahra()
        {
            Console.WriteLine("please enter value to random them betwen ");
            Console.Write("from ");
            int ran = Convert.ToInt32(Console.ReadLine());
            Console.Write("\n to ");
            int to = Convert.ToInt32(Console.ReadLine());
            to++;
            Random r=new Random();
            Console.WriteLine(r.Next(ran, to));
        }
    }
    }
