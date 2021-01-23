        static string GenerateCoupon(Random r)
        {
            string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            int size = 4;
            char[] code1 = new char[size];
            char[] code2 = new char[size];
            char[] code3 = new char[size];
            for (int i = 0; i < size; i++)
            {
                code1[i] = Alphabet[r.Next(Alphabet.Length)];
                code2[i] = Alphabet[r.Next(Alphabet.Length)];
                code3[i] = Alphabet[r.Next(Alphabet.Length)];
            }
            string code4 = new string(code1);
            string code5 = new string(code2);
            string code6 = new string(code3);
            return string.Format("{0}-{1}-{2}", code4, code5, code6);
        }
        static void Main(string[] args)
        {
            Random rnd = new Random();
            for (int i = 0; i < 100;i++ )
                Console.WriteLine(GenerateCoupon(rnd));
             Console.ReadLine();
        }
