      public static bool StripHTMLAndCheckVisible(string HTMLText)
        {
            if (string.IsNullOrEmpty(HTMLText))
                return false;
            else
            {
                Regex regJs=new Regex(@"(?s)<\s?script.*?(/\s?>|<\s?/\s?script\s?>)",RegexOptions.IgnoreCase);
                HTMLText = regJs.Replace(HTMLText, "");
                Regex reg = new Regex("<[^>]+>", RegexOptions.IgnoreCase);
                HTMLText = reg.Replace(HTMLText, "");
                return string.IsNullOrEmpty(HTMLText) ? false : true;
            }
        }
