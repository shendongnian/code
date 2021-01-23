    class Program
    {
        static List<string> listOfPrepositions = new List<string>()
            {
                "de",
                "da",
                "dos"
            };
        static void Main(string[] args)
        {
            var somestring = "asdf aaa Asdf";
            Console.WriteLine(UppercaseName(somestring));
            Console.ReadLine();
        }
        static string UppercaseName(string fullName)
        {
            var split = fullName.Split(' ');
            var returnedName = "";
            foreach (var name in split)
            {
                if (name.Length == 0)
                    continue;
                if (listOfPrepositions.Where(p => p.Equals(name)).Count() > 0)
                {
                    returnedName += name + " ";
                    continue; // skip if it's a preposition
                }
                // Set the first character in the string to be uppercase
                returnedName += char.ToUpper(name[0]) + name.Substring(1) + " ";
                
            }
            returnedName.TrimEnd(' ');
            return returnedName;
        }
    }
