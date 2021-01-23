    public class HttpHeaderParser
    {
        public NameValueCollection Parse(string header)
        {
            var result = new NameValueCollection();
                        
            // 'register' any string values;
            var stringLiteralRx = new Regex(@"""(?<content>(\\""|[^\""])+?)""", RegexOptions.IgnorePatternWhitespace);
            var equalsRx = new Regex("=", RegexOptions.IgnorePatternWhitespace);
            var semiRx = new Regex(";", RegexOptions.IgnorePatternWhitespace);
            Dictionary<string, string> literalStrings = new Dictionary<string, string>();
            var cleanedHeader = stringLiteralRx.Replace(header, m =>
            {
                var replacement = "PLACEHOLDER" + Guid.NewGuid().ToString("N");
                var stringLiteral = m.Groups["content"].Value.Replace("\\\"", "\"");
                literalStrings.Add(replacement, stringLiteral);
                return replacement;
            });
            
            // now it's safe to split on semicolons to get name-value pairs
            var nameValuePairs = semiRx.Split(cleanedHeader);
            foreach(var nameValuePair in nameValuePairs)
            {
                var nameAndValuePieces = equalsRx.Split(nameValuePair);
                var name = nameAndValuePieces[0].Trim();
                var value = nameAndValuePieces[1];
                string replacementValue;
                if (literalStrings.TryGetValue(value, out replacementValue))
                {
                    value = replacementValue;
                }
                result.Add(name, value);
            }
            return result;
            
        }
    }
