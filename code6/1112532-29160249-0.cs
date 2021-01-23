    public static string RemoveHTMLTags(string content)
            {
                var cleaned = string.Empty;
                try
                {
                    string textOnly = string.Empty;
                    Regex tagRemove = new Regex(@"<[^>]*(>|$)");
                    Regex compressSpaces = new Regex(@"[\s\r\n]+");
                    textOnly = tagRemove.Replace(content, string.Empty);
                    textOnly = compressSpaces.Replace(textOnly, " ");
                    cleaned = textOnly;
                }
                catch
                {
                    //A tag is probably not closed. fallback to regex string clean.
    
                }
    
                return cleaned;
            }
