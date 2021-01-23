       static void Main(string[] args)
        {
            string sampleResult = NormlizeAlphaNumeric("Hello wordl 3242348&&))&)*^&#R&#&R#)R#@)R#@R#R#@");
        }
        public static string NormlizeAlphaNumeric(string someValue)
        {
            var sb = new StringBuilder(someValue.Length);
            foreach (var ch in someValue)
            {
                if(char.IsLetterOrDigit(ch))
                {
                    sb.Append(ch);
                }
            }
            return sb.ToString().ToLower();
        }
