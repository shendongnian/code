    List<string> words = new List<string> { "a","b",....~100k Items};
    
    //You need 
    string pattern = @"\b(" + 
                     String.Join("|", 
                        words.Select(x=>Regex.Escape(x)) + //You need "using System.Linq;" to use "words.Select"
                     @")\b";
    Regex r = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace | RgexOptions.Multiline | RegexOptions.Compiled);
    
    Label1.Text = r.Replace(TextBox1.Text, @"<b>$1</b>");
