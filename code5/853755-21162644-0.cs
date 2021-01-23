    try
    {
        var sFormula = formula.Text;
        string pattern = "\"[\\w ]*\"";
        Regex r = new Regex(pattern);
        MatchCollection mc = r.Matches(sFormula);
    
        foreach (Match m in mc)
        {
            var sValue =m.Value;
            var sParsedValue = sValue.Substring(1, sValue.Length - 2);
    
            if (sParsedValue.StartsWith("s"))
            {
                var stest = "\"" + CApplicationData.TranslateStringValue(sParsedValue) + "\"";
                sFormula = sFormula.Replace(sValue, stest);
            }
        }
    
        formula.Text = sFormula;
    }
    catch{}
