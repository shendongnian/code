    internal class Program
    {
        private static void Main()
        {
            const string unicodetxt1 = "ஊரவர் கெளவை";
            List<string> output = Syllabify(unicodetxt1);
            Console.WriteLine(output.Count);
            const string unicodetxt2 = "கௌவை";
            output = Syllabify(unicodetxt2);
            Console.WriteLine(output.Count);
        }
    
        public static string CheckVisualGlyphPattern(string txt)
        {
            string[] data = txt.Split(new[] { ' ', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            string list = string.Empty;
            var rx = new Regex("^(.*?){1}(\u0bc6){1}(\u0bb3){1}");
            foreach (string s in data)
            {
                var matches = new List<Match>();
                string outputs = rx.Replace(s, match =>
                {
                    matches.Add(match);
                    return string.Format("{0}\u0bcc", match.Groups[1].Value);
                });
                list += string.Format("{0} ", outputs);
            }
            return list.Trim();
        }
    
        public static List<string> Syllabify(string unicodetext)
        {
            var processdata = CheckVisualGlyphPattern(unicodetext);
            if (string.IsNullOrEmpty(processdata)) return null;
            TextElementEnumerator enumerator = StringInfo.GetTextElementEnumerator(processdata);
            var data = new List<string>();
            while (enumerator.MoveNext())
                data.Add(enumerator.Current.ToString());
            return data;
        }
    }
