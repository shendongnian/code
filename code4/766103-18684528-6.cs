    public static class StringExtensions
    { 
        static readonly Regex re = new Regex( @"(.)\1*", RegexOptions.Compiled );                
        public static string Compress(this string theString)
        {
            return re.Replace( theString, match => match.Value[0] + match.Length.ToString() );             
        }
    }
