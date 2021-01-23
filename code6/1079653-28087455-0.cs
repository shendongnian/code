    private static string[] BreakContentIntoCategories(string lines)
        {
            string[] categories = new string[3];
            int place = 0;
            lines = lines.Replace("\r\n", "\n");
            string[] line = lines.Split('\n');
            for (int i = 0; i < line.Length; i++)
            {
                if (line[i].StartsWith("#"))
                {
                    string[] category = new string[2];
                    category[0] = line[i].Substring(1);
                    category[1] = line[i + 1];
                    Console.WriteLine(category[0]);
                    Console.WriteLine(category[1]);
                    // Problem lies here
                    Console.WriteLine(category[0] + category[1]);
                    Console.WriteLine("-----------------");
                    categories[place] = string.Join("", category);
                    place++;
                }
            }
            return categories;
        }
