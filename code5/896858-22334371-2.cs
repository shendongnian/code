    class Program
    {
        static void Main()
        {
            string text = "<a href=\"\" id=\"test\">";
            string pattern = "src|href";
            string absoluteUrl = "YADA";
            string value = Regex.Replace(text, "<(.*?)(" + pattern + ")=\"(?!http|javascript|#)(.*?)\"(.*?)>", "<$1$2=\"" + absoluteUrl + "$3\"$4>", RegexOptions.IgnoreCase | RegexOptions.Multiline);
    
            Console.WriteLine(value);
        }
    }
