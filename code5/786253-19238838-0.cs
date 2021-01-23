        static void Main(string[] args)
        {
            string baseList = "abcdefghijklmnopqrstuvwxyz";
            Console.WriteLine(baseList);
            string shuffled = Shuffle(baseList);
            Console.WriteLine(shuffled);
            Console.ReadLine();
        }
        static Random R = new Random();
        static string Shuffle(string list)
        {
            int index;
            List<char> chars = new List<char>(list);
            StringBuilder sb = new StringBuilder();
            while (chars.Count > 0)
            {
                index = R.Next(chars.Count);
                sb.Append(chars[index]);
                chars.RemoveAt(index);
            }
            return sb.ToString();
        }
