            string s = "00000000000000000000";
            string input = "20";
            List<string> list = new List<string>();
            foreach (var item in s)
            {
                list.Add(Convert.ToString(item));
            }
            list.Add(input);
            int count = input.Length;
            list.RemoveRange(0, count);
            StringBuilder result = new StringBuilder();
            foreach (var item in list)
            {
                result.Append(item.ToString());
            }
            Console.WriteLine(result);
            Console.WriteLine(result.Length);
