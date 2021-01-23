    static void Main(string[] args)
        {
            StreamReader tbal = new StreamReader("tbal.dat");
            string contents = tbal.ReadToEnd().Trim();
            string[] split = contents.Split('|');
            Console.WriteLine("*****LOADING*****");
            StreamWriter writer = new StreamWriter("Test.txt", true);
            foreach (string s in split)
            {
                writer.WriteLine(s);
                Console.WriteLine(s);
            }
            tbal.Close();
            writer.Close();
            Console.WriteLine("*****Complete*****");
        }
