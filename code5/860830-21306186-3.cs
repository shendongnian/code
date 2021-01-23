    private static PriceRange ExtractRange(MyClass o) {
        if (o.Price < 10)
            return PriceRange.LessThanTen;
        else if (o.Price <= 20)
            return PriceRange.TenToTwenty;
        else
            return PriceRange.MoreThanTwenty;
    }
