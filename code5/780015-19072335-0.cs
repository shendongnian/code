    private decimal price = 0.00M;
    /// <summary>
    /// Sets and gets the Price property.
    /// Changes to that property's value raise the PropertyChanged event. 
    /// </summary>
    public decimal Price
    {
        get
        {
            return price;
        }
        set
        {
            if (price == value)
            {
                return;
            }
            RaisePropertyChanging(() => Price);
            price = value;
            RaisePropertyChanged(() => Price);
            this.PriceStr = this.Price.ToString();
           
        }
    }
    private string priceStr=0.00M.ToString();
    /// <summary>
    /// Sets and gets the Price property.
    /// Changes to that property's value raise the PropertyChanged event. 
    /// </summary>
    public string PriceStr
    {
        get
        {
            return priceStr;
        }
        set
        {
            if (priceStr == value)
            {
                return;
            }
            priceStr = value;
            isPriceAValidStr=decimal.TryParse(this.PriceStr, out price);
           
            RaisePropertyChanged(() => Price);
            RaisePropertyChanged(() => PriceStr);
        }
    }
            private bool isPriceAValidStr = true;
