        static void Main(string[] args)
        {
            String s = "aaa";
            Console.WriteLine(s); // Prints aaa
            F(s);
            Console.WriteLine(s); // Prints aba
            Console.ReadLine();
        }
        static unsafe void F(String s)
        {
            fixed (char* p = s)
            {
                p[1] = 'b';
            }
        }
