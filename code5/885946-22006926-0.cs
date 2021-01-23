       static void Main(string[] args)
        {
  
            var names = new List<String>() {
            "access",
            "Addition",
            "ADDition",
            "ADdition",
            "account",
             "base",
            "Brick",
            "zammer",
            "Zilon"
            };
            names.Sort((one, two) =>
            {
                int result = 0;
                var oneArray = one.ToCharArray();
                var twoArray = two.ToCharArray();
                var minLength = Math.Min(oneArray.Length, twoArray.Length) - 1;
                var i = 0;
                while (i < minLength)
                {
                    //Diff Letter
                    if (Char.ToUpper(one[i]) != Char.ToUpper(two[i]))
                    {
                        result = Char.ToUpper(one[i]) - Char.ToUpper(two[i]);
                        break;
                    }
                    // Same Letter, same case
                    if (oneArray[i] == twoArray[i])
                    {
                        i++;
                        continue;
                    }
                    // Same Letter, diff case
                    result =  one[i] - two[i];
                    break;
                }
                return result;
            });
            foreach (string s in names)
                Console.WriteLine(s);
            Console.WriteLine("done");
