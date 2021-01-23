    public string MissingCount
    {
        get 
        {
            int missingCount = intRedItem - intBlueItem;
            return missingCount == 0 ? "Even" : missingCount.ToString();
        }
    }
