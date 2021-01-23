        string str = string.Empty , outPut = string.Empty;
            Regex paternWithDot = new Regex(@"\d+(\.\d+)+");
            Regex paternWithComa = new Regex(@"\d+(\,\d+)+");
            Match match = null;
            
            
            str = "& 34.34";
            if (str.Contains(".")) match = paternWithDot.Match(str);
            if (str.Contains(",")) match = paternWithComa.Match(str);
            outPut += string.Format( @" currency sign = ""{0}"" and amount = {1}" , str.Replace(match.Value, string.Empty),  match.Value) + Environment.NewLine;
            str = "€ 20.34 ";
            if (str.Contains(".")) match = paternWithDot.Match(str);
            if (str.Contains(",")) match = paternWithComa.Match(str);
            outPut += string.Format(@" currency sign = ""{0}"" and amount = {1}", str.Replace(match.Value, string.Empty), match.Value) + Environment.NewLine;
            str = "£ 190,234";
            if (str.Contains(".")) match = paternWithDot.Match(str);
            if (str.Contains(",")) match = paternWithComa.Match(str);
            outPut += string.Format(@" currency sign = ""{0}"" and amount = {1}", str.Replace(match.Value, string.Empty), match.Value) + Environment.NewLine;
            str = "$  20.34 ";
            if (str.Contains(".")) match = paternWithDot.Match(str);
            if (str.Contains(",")) match = paternWithComa.Match(str);
            outPut += string.Format(@" currency sign = ""{0}"" and amount = {1}", str.Replace(match.Value, string.Empty), match.Value) + Environment.NewLine;
            MessageBox.Show(outPut);
