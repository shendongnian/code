    using System.Text.RegularExpressions;
    public static class NustacheUtil
    {
        public static string PreProcess(string templateString)
        {
            return Regex.Replace(templateString, @"{{(.*?)\|(\d+)}}", @"<###{{$1}}|$2###>");
        }
        public static string PostProcess(string templateString)
        {
            var result = templateString;
            for(;;)
            {
                var match = Regex.Match(result, @"<###([0-9.]+?)\|(\d+)###>");
                if(!match.Success || match.Groups.Count != 3)
                {
                    break;
                }
                decimal value;
                if(decimal.TryParse(match.Groups[1].Value, out value))
                {
                    var numDecimalPlaces = match.Groups[2].Value;
                    result = result.Remove(match.Index, match.Length);
                    result = result.Insert(match.Index, value.ToString("N" + numDecimalPlaces));
                }
            }
            return result;
        }
    }
