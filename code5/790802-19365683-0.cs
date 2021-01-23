                string pattern = "(\\d*x* )";
                string[] myArray = { "1x Car green", "2x Plane red", "3x boat blue", "etc", "etc" };
                var result = myArray.Select(p => Regex.Replace(p, pattern, String.Empty)).ToArray();
    
                foreach (string name in result)
                    Console.WriteLine(name);
