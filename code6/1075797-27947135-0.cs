    private string _charterSellPriceCurrency;
    private Nullable<decimal> _margin;
    
    public string CharterSellPriceCurrency 
    {
        get
        {
            return _charterSellPriceCurrency;
        }
        private set
        {
            if (value != _charterSellPriceCurrency)
            {
                _charterSellPriceCurrency = value;
                OnPropertyChanged("CharterSellPriceCurrency");
                CalculateMargin();
            }
        }
    }
    
    public Nullable<decimal> Margin
    {
        get
        {
            return _margin;
        }
        private set
        {
            if (value != _margin)
            {
                _margin = value;
                OnPropertyChanged("Margin");
            }
        }
    }
    
    private void CalculateMargin()
    {
        if (_charterSellPriceCurrency == null)
        {
            Margin = null;
            return;
        }
    
        if (_sellPrice.HasValue && _buyPrice.HasValue)
        {
            Margin = _exchangeRateConverter.ConvertUsingExchangeRate(1, _sellPriceCurrency.Name, _charterSellPriceCurrency.Name, _sellPrice.Value) -
                    _exchangeRateConverter.ConvertUsingExchangeRate(1, _buyPriceCurrency.Name, _charterSellPriceCurrency.Name, _buyPrice.Value);
            return;
        }
    
        Margin = null;
    }
