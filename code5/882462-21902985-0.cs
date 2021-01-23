    class Program
    {
        static void Main()
        {
            string[] strArray = new string[] { "cello", "guitar", "violin" };
            string[] vowels = new string[] { "a", "e", "i", "o", "u" };
            var vNovowels = from vitem in strArray
                            select vitem.RemoveAll(vowels);
            foreach (var item in vNovowels)
            {
                Console.WriteLine(item);
            }
        }
    }
    static class Extensions
    {
        public static string RemoveAll(this string input, IEnumerable<string> toRemove)
        {
            string res = input;
            foreach (var c in toRemove)
            {
                res = res.Replace(c, "");
            }
            return res;
        }
    }
