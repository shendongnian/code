    class Program
    {
        static void Main(string[] args)
        {
            string text = "This is random text!";
            var sha = new SHA512Managed();
            byte[] hash = sha.ComputeHash(Encoding.ASCII.GetBytes(text));
            Console.WriteLine("Input text: " + text);
            Console.WriteLine("SHA512: ");
            for (int i = 0; i < hash.Length; i += 4)
            {
                Console.Write(" {0}{1}{2}{3} ",
                    Convert.ToString(hash[i], 16),
                    Convert.ToString(hash[i + 1], 16),
                    Convert.ToString(hash[i + 2], 16),
                    Convert.ToString(hash[i + 3], 16));
            }
            Console.ReadLine();
        }
    }
