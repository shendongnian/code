    private readonly List<AnItemType> _previousDayPrices;
    private void PrintDebugPreviousDayPrice(DateTime date)
    {
        StringBuilder stringBuilder = new StringBuilder();
        foreach (AnItemType item in _previousDayPrices)
        {
            String valueToAppend = String.Format(
                "{0}-{1}-{2}-{3},",
                item.Price,
                item.Date,
                item.EuroExchangeRateDate,
                item.EuroExchangeRate);
            stringBuilder.Append(valueToAppend);
        }
    }
