    private double GetRoundUpValue(double price, int places)
    {
        var minValue = Math.Pow(0.1, places);
        return Math.Max(Math.Round(price, places, MidpointRounding.AwayFromZero), minValue);
    }
