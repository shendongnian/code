         public string Between(string STR, string FirstString, string LastString)
         {
             string regularExpressionPattern1 = @"(?:\" + FirstString + @")([^[]+)\[\/" + LastString;
            Regex regex = new Regex(regularExpressionPattern1, RegexOptions.Singleline);
            MatchCollection collection = regex.Matches(STR.ToString());
            var val = string.Empty;
            foreach (Match m in collection)
            {
                val = m.Groups[1].Value;
            }
            return val;
         }
