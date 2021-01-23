    public static int Total(this IEnumerable<Item> items)
    {
        int confirmedTotal = 0;
        int unconfirmedTotal = 0;
        int unconfirmedCount = 0;
        foreach (var item in items)
        {
            if (item.IsConfirmed)
            {
                confirmedTotal += item.Qty;
            }
            else
            {
                unconfirmedCount++;
                unconfirmedTotal += item.Qty;
            }
        }
        if (unconfirmedCount == 0)
            return confirmedTotal;
        // NOTE: Will not throw if there is no unconfirmed items
        return confirmedTotal + unconfirmedTotal / unconfirmedCount;
    }
