    using System.Text.RegularExpressions;
    ...
    class Program
    {
        static int occurence = 0;
        static string[] defValues = new string[] { "DefName", "DefRace", "DefHeight", "DefHair" };
        static string ReplaceWithDefault(Match m)
        {
            if (occurence < defValues.Length)
                return defValues[occurence++];
            else
                return "NO_DEFAULT_VALUE_FOUND";
        }
             
        static void Main(string[] args)
        {
            string exampleString = "My name is {Name}. I was born as {Race}. I am {Height} tall. My hair is {HairLength}.";
            string replaced = Regex.Replace(exampleString, "\\{[^\\}]+\\}", new MatchEvaluator(ReplaceWithDefault));
            occurence = 0;
            Console.WriteLine(exampleString);
            Console.WriteLine(replaced);
        }
    }
