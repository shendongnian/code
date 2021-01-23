    // Your calling code would now just be...
    
    double amountToConvert = double.Parse(textBoxInputMoney.Text);
    CurrencyConverter currencyExchanger = new CurrencyConverter(new ExchangeRateRepository());
    currencyExchanger.Convert(amountToConvert, comboBoxInputMoney.Text, comboBoxOutputMoney.Text);
    // ...
    public class CurrencyConverter
    {
        private IExchangeRateRepository exchangeRateRepository;
        public CurrencyConverter(IExchangeRateRepository repository)
        {
            exchangeRateRepository = repository;
        }
        public string Convert(double amount, string fromCurrency, string toCurrency)
        {
            var fromRates = exchangeRateRepository.Rates.SingleOrDefault(a => a.Key == fromCurrency);
            if (fromRates.Key != null)
            {
                var toRate = fromRates.Value.SingleOrDefault(a => a.Key == toCurrency);
                if (toRate.Key != null)
                {
                    return (amount * toRate.Value) + toCurrency;
                }
            }
            return string.Empty;
        }
    }
    public interface IExchangeRateRepository
    {
        Dictionary<string, Dictionary<string, double>> Rates { get; }
    }
    public class ExchangeRateRepository : IExchangeRateRepository
    {
        private Dictionary<string, Dictionary<string, double>> exchangeRatesLookup = new Dictionary
            <string, Dictionary<string, double>>
                                                                                         {
                                                                                             {
                                                                                                 "USD",
                                                                                                 new Dictionary
                                                                                                 <string, double>()
                                                                                                     {
                                                                                                         {"EUR", 0.74},
                                                                                                         {"CHF", 0.92},
                                                                                                         {"GBP", 0.6}
                                                                                                     }
                                                                                             },
                                                                                             {
                                                                                                 "EUR",
                                                                                                 new Dictionary
                                                                                                 <string, double>()
                                                                                                     {
                                                                                                         {"USD", 1.35},
                                                                                                         {"CHF", 1.23},
                                                                                                         {"GBP", 1.1}
                                                                                                     }
                                                                                             },
                                                                                         };
        public Dictionary<string, Dictionary<string, double>> Rates
        {
            get
            {
                return exchangeRatesLookup;
            }
        }
    }
