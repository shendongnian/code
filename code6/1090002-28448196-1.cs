         public string Between(string STR, string FirstString, string LastString)
         {
            string FinalString = @"(?:\"+FirstString+")([^[]+)\[\/"+LastString+";
            Regex regex = new Regex(regularExpressionPattern1, RegexOptions.Singleline);
            MatchCollection collection = regex.Matches(value.ToString());
            Match m = collection[0];
            return m.Groups[1].Value;
         }
