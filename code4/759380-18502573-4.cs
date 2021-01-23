    private decimal? _calculateOrderPrice;
    public decimal CalculateOrderPrice
    {
        get
        {
            if (_calculateOrderPrice == null)
            {
                _calculateOrderPrice = products.Sum(p => p.Price*p.Quantity;
            }
            return _calculateOrderPrice.Value;
        }
    }
