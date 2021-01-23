        static void Main(string[] args)
        {
            const int minJpnCharCode = 0x4e00;
            const int maxJpnCharCode = 0x4f80;
            var random = new Random();
            for (int i = 0; i < 10000; i++)
            {
                Console.WriteLine(GenerateString(random.Next(0, 50), minJpnCharCode, maxJpnCharCode));                
            }
            Console.ReadLine();
        }
