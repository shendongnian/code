    public class QuoteFactory : IQuoteFactory{
        public QuoteFactory(Quote boatQ, Quote motorQ, Quote carQ){
            // parameter assignment
        }
        Quote boatQ;
        Quote motorQ;
        Quote carQ;
    
        public Quote Create(string quote){
            if(quote == "car") return carQ;
            //further condition
        }
    }
