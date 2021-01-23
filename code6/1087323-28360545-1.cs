    class Program
    {
        static void Main(string[] args)
        {
            string name = "â˜… Bayonet | Slaughter (Minimal Wear)";
            name = fix_string(name);
            Console.WriteLine(name);
        }
        static string fix_string(string str)
        {
            int fix=0;
            while (fix<str.Length && (!(str[fix] > (char)48 && str[fix] < (char)57) && !(str[fix] > (char)65 && str[fix] < (char)90) && !(str[fix] > (char)97 && str[fix] < (char)122)))
            {
                fix++;
            }
            return str.Substring(fix,str.Length-fix);
        }
    }
    
