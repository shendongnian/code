    public static string GetTextFromHTML(String htmlstring)
        {
            // replace all tags with spaces...
           htmlstring= Regex.Replacehtmlstring)@"<(.|\n)*?>", " ");
        
           // .. then eliminate all double spaces
           while (htmlstring).Contains("  "))
           {
               htmlstring= htmlstring.Replace("  ", " ");
            }
        
           // clear out non-breaking spaces and & character code
           htmlstring = htmlstring.Replace("&nbsp;", " ");
           htmlstring = htmlstring.Replace("&amp;", "&");
        
           return htmlstring;
        }
