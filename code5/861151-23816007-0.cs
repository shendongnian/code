    public class CustomAnalyzer : SnowballAnalyzer
    {
        public CustomAnalyzer() : base("French") { }
        public override TokenStream TokenStream(string fieldName, TextReader reader)
        {
            TokenStream result = base.TokenStream(fieldName, reader);
            result = new ISOLatin1AccentFilter(result);
            return result;
        }
    }
