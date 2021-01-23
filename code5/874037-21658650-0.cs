    string value = "Somethingg1 Cwts/Rotc/Lts Cwts";
    var replacementValues = new Dictionary<string, string>()
                       {
                         {"Cwts","CWTS"},
                         {"Rotc","ROTC"},
                         {"Lts","LTC"}
                       };
    var regExpression = new Regex(String.Join("|", replacementValues.Keys.Select(x => Regex.Escape(x))));
    var outputString = regExpression.Replace(value, s => replacementValues[s.Value]);
