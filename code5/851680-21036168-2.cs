    private static Object thisLock = new Object();
    public static string GetValue(List<StateBag> stateBagList, string name)
    {
        string retValue = string.Empty;
        
        if (stateBagList != null)
        {
            lock(thisLock)
            {
                foreach (StateBag stateBag in stateBagList)
                {
                   if (stateBag.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase))
                   {
                    retValue = stateBag.Value;
                    }
                 }
            }
        }
        
        return retValue;
    }
