    public class QuoteFactory : IQuoteFactory
    {
        public TQuote CreateQuote<TQuote>()
            where TQuote : new() // or Quote if specific attributes requied to be set by factory
        {
            return new TQuote();
        }
    }
