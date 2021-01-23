    class Program
    {
        static void Main(string[] args)
        {
            var input = "I whish you a merry Christmas and a happy new year.";
            var list = new List<string>();
            var temp = 0;
            var index = 15;
            while (true)
            {
                if (input[index] == ' ')
                {
                    list.Add(input.Substring(temp, 15));
                    temp = index + 1;
                }
                else
                {
                    for (var j = index; j > 0; j--)
                    {
                        if (input[j] == ' ')
                        {
                            list.Add(input.Substring(temp, j - temp));
                            index = temp = j;
                            temp++;
                            break;
                        }
                    }
                }
                index += 16;
                if (index >= input.Count() - 1)
                {
                    list.Add(input.Substring(temp, input.Length - 1 - temp));
                    break;
                }
            }
            var sb = new StringBuilder();
            list.ForEach(str => sb.Append(str + "\r\n\t"));
            Console.WriteLine(sb.ToString());
            Console.ReadKey();
        }
    }
