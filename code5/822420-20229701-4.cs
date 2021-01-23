    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace ConsoleApplication1
    {
        class Program
        {
            public static void Main(string[] args)
            {
                string arg1 = null;
                if (args.Length > 0)
                    arg1 = args[0];
                Console.WriteLine(arg1);
                Console.WriteLine(args);
                string tf = "\tf1.txt";
                string tf1 = arg1 + tf;
                Console.WriteLine(tf1);
                System.Console.Title = "Data Adder (For the test)";
                Random rnd = new Random();
                int r1 = rnd.Next(0, 20);
                byte[] bytes = new byte[255 * r1];
                for (int i = 0; i < bytes.Length; i++)
                    bytes[i] = 65;
                string filepath = Path.Combine(arg1, @"\tf1.txt");
                if (File.Exists(filepath))
                {
                    var TF1 = new BinaryWriter(File.Open(filepath, FileMode.Open));
                    TF1.Write(bytes);
                    TF1.Close();
                }
                Console.ReadKey();
            }
            private static int Random(int p1, int p2)
            {
                throw new NotImplementedException();
            }
        }
    }
