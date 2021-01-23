    using System;
    using System.Text.RegularExpressions;
    public class Example
    {
        public static void Main()
        {
            string pattern = @"\w+";
            Regex regex = new Regex(pattern);
            string sentence = "AUSTIN,ORL2,ORL6\nCHA,INDY";
            foreach (Match match in regex.Matches(sentence))
            {
                Console.WriteLine("<a href='details.aspx?location={0}'>{0}</a>",
                                  match.Value);
            }
        }
    }
