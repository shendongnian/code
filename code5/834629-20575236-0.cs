    [FieldOrder(3)]
    private double _price;
    public string price
    {
        get { return string.Format("{0}$", _price.ToString()); }
        set { _price = Convert.ToDouble(value.replace('$', '')); }
    }
