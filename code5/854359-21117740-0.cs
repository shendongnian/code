    HashSet<int> items = new HashSet<int>(itemsList);
    foreach (int price in items)
    {
        int otherPrice = 200 - price;
        if (items.Contains(otherPrice))
        {
            // found a match.
            break;
        }
    }
