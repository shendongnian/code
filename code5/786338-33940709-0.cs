    private string RemoveSpaces(string text)
            {
                var reg = new System.Text.RegularExpressions.Regex(" +");
                return reg.Replace(text, " ").Trim();            
            }
