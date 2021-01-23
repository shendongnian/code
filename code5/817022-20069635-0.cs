    Dictionary<int, int> NumberLookup = new Dictionary<int, int>();
    public void CalculcateNextFactor()
    {        
        int nextNumber = // calculate the next number...
        if (NumberLookup.ContainsKey(nextNumber))
            NumberLookup[nextNumber]++;
        else
            NumberLookup.Add(nextNumber, 1);
    }
