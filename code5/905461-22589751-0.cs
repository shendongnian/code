        static void Main()
        {
            string input = "1|2|3|4,5,6|7,8|9|23|29,33";
            Console.WriteLine(ReplaceByIndex(input, "hello", 23));
            Console.ReadLine();
        }
        static string ReplaceByIndex(string input, string replaceWith, int index)
        {
            int indexStart = input.IndexOf(index.ToString());
            int indexEnd = input.IndexOf(",", indexStart);
            if (input.IndexOf("|", indexStart) < indexEnd)
                indexEnd = input.IndexOf("|", indexStart);
            string part1 = input.Substring(0, indexStart);
            string part2 = "";
            if (indexEnd > 0)
            {
                part2 = input.Substring(indexEnd, input.Length - indexEnd);
            }
            return part1 + replaceWith + part2;
        }
