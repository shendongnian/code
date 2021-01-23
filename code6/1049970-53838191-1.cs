    [Route("/QuoteFeed/GetQuote/{Symbol}", Summary = "Retreive a price quote for the requested symbol.")]
    public class GetQuote : IReturn<QuoteDataResponse>
    {
        [DataMember, ProtoMember(1)]
        [ApiMember(Name = "Symbol",
             Description = "The symbol, in the providers given format, for which a quote should be given.",
             DataType = "string",
             IsRequired = true)]
        public string Symbol { get; set; } 
    }
