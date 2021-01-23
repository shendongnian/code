    if (!String.IsNullOrEmpty(searchItemcode))
    {
        var itemList = searchItemcode.Split(',').Select(p => double.Parse(p.Trim()));
        priceHistory = priceHistory.Where(s => itemList.Contains(s.ITEM_CODE));
    }
