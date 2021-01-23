    public interface IStockQuoteCallback
    {
        Task SendQuote(string code, double value);
    }
    public interface IStockQuoteServiceCallback 
    {
        void SendQuote(string code, double value);
    }
