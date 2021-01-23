    private string GetFirstParagraph(string yourHtmltext)
        {
            Match m = Regex.Match(yourHtmltext, @"<p>\s*(.+?)\s*</p>");
            if (m.Success)
            {
                return m.Groups[1].Value;
            }
            else
            {
                return yourHtmltext;
            }
        }
