    class Program
    {
        static void Main(string[] args)
        {
            // {"html":"\n\t\t\t\t<table class=\"table\">"} 
            var s = "{\"html\":\"\n\t\t\t\t<table class=\\\"table\\\">\"}";
            Console.WriteLine("\"{0}\"", ParseJson("html", s).First());
            // You might wanna do Trim() on the string because of those \t\t\t etc.
        }
        static private IEnumerable<string> ParseJson(string key, string input)
        {
            Regex r = new Regex(@"\{\""html\""\:\""(.*?)(?<!\\)\""\}", RegexOptions.Singleline);
            return r.Matches(input).Cast<Match>().Select(T => T.Groups[1].Value);
        }
    }
