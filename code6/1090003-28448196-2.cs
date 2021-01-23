         public string Between(string STR, string FirstString, string LastString)
         {
            string FinalString = @"(?:\"+FirstString+")([^[]+)\[\/"+LastString+";
            Regex regex = new Regex(regularExpressionPattern1, RegexOptions.Singleline);
            MatchCollection collection = regex.Matches(value.ToString());
            var val;
            foreach(Match m in collection)
             {
                 val = .Groups[1].Value;
             }
            
            return val;
         }
