    public class CountCharacter
    {
        public static void Main (string[] args)
        {
            string s = "most computer students like to play games";
            Console.WriteLine(countCharacters(s));
        }
       public static int countCharacters( string s, char c)
        {
            if (s.Length ==0)
                return 0;
            else if (s[0]==c)
                return 1 + countCharacters(s.Substring(1), c);
            else
                return 0 + countCharacters(s.Substring(1), c);
        }
    }
