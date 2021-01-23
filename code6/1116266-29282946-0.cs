    public enum CurrencyType
    {
        USD = 0,
        EUR = 1 //etc..
    }
    public class Money
    {
        public CurrencyType CurrenyType { get; set; }
        public decimal Value { get; set; }
        public Money(XElement element)
        {
            if (element.Name.LocalName != "Money")
                throw new Exception(...);
            var aCurrency = element.Attribute("currency");
            this.CurrencyType = aCurrency == null || string.IsNullOrEmpty(aCurrency.Value) ? CurrencyType.USD : (CurrencyType)Enum.Parse(typeof(CurrencyType), aCurrency.Value);
            this.Value = element != null && !string.IsNullOrEmpty(element.Value) ? element.Value : 0;
        }
    }
