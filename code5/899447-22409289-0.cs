    public static IEnumerable<PaymentRateTrip> Sort(this IEnumerable<PaymentRateTrip> list, string sort)
    {
        switch (sort)
        {
            case "homeCountry":
                return list.OrderBy(x => x.Whatever);
            case "somethingElse":
                return list.OrderBy(x => x.Whatever);
		
            //....
        }
    }
