    public abstract class AnalyzerView
    {
        public abstract string Name { get; }
        public virtual string GetView(TokenStream tokenStream,out int numberOfTokens)
        {
            StringBuilder sb = new StringBuilder();
            numberOfTokens = 0;
            while (tokenStream.IncrementToken())
            {
                numberOfTokens++;
                sb.Append(GetTokenView(tokenStream));
            }
            return sb.ToString();
        }
        protected abstract string GetTokenView(TokenStream tokenStream);
    }
