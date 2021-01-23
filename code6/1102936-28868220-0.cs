    public static class Extensions
    {
        public static decimal GetMarkedUpPrice(this decimal basePrice, decimal percentMarkup)
        {
            return basePrice * (1 + percentMarkup);
        }
    }
