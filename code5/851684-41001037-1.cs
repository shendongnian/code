    public static string GetValue(List<StateBag> stateBagList, string name)
    {
        if (stateBagList != null)
        {
            lock (thisLock)
            {
                return stateBagList.FirstOrDefault
                     (x => x.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase));
                }
            }
        }    
        return string.Empty;
    }
