    int Compare(Entry a, Entry b)
    {
        if (a.Type == b.Type)
        {
            // same type, look at the price difference and reverse if they are both Bids
            return a.Price.CompareTo(b.Price) * (a.Type == "Bid" ? -1 : 1);
        }
        else
        {
            // different types, Ask comes first
            return (a.Type == "Ask") ? -1 : 1;
        }
    }
