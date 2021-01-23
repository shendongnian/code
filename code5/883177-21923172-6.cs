    static List<int> Spread(int numDays, int numItems)
    {
        List<int> result = new List<int>();
        if (numDays <= 1)
        {
            if (numDays == 1)
                result.Add(numItems);
            return result;
        }
        int numItemsInDayLower = numItems/numDays;
        int numItemsInDayHigher = numItemsInDayLower+1;
        int numDaysHigher = numItems - numItemsInDayLower * numDays;
        int numDaysLower = numDays-numDaysHigher;
        int numSpansLower = numDaysLower > numDaysHigher ? numDaysHigher + 1 : numDaysLower;
        int numSpansHigher = numDaysHigher > numDaysLower ? numDaysLower + 1 : numDaysHigher;
        bool isStartingFromSpanLower = numDaysLower > numDaysHigher;
        List<int> spanLehgthsLower = Spread(numSpansLower, numDaysLower);
        List<int> spanLehgthsHigher = Spread(numSpansHigher, numDaysHigher);
        for (int iSpan = 0; iSpan < spanLehgthsLower.Count + spanLehgthsHigher.Count; iSpan++)
        {
            if ((iSpan % 2 == 0) == isStartingFromSpanLower)
            {
                for (int i = 0; i < spanLehgthsLower[iSpan/2]; i++)
                    result.Add(numItemsInDayLower);
            }
            else
            {
                for (int i = 0; i < spanLehgthsHigher[iSpan/2]; i++)
                    result.Add(numItemsInDayHigher);
            }
        }
        return result;
    }
