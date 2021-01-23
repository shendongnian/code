        static void Main(string[] args)
        {
            Regex digitRegex = new Regex("(\\d)");
            string text = Console.ReadLine();
            int wordCount = text.Split(new char[]{' '}, StringSplitOptions.RemoveEmptyEntries).Length;
            int sum = 0;
            foreach (Match x in digitRegex.Matches(text, 0))
            {
                int num;
                if (int.TryParse(x.Value, out num))
                    sum += num;
            }
            Console.WriteLine("Word Count:{0}, Digits Total:{1}", wordCount, sum);
            Console.ReadLine();
        }
