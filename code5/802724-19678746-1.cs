    public static int NextIncrementalValueNotInList(this int value, 
      List<int> ListOfIntegers)
    {
        int i = value;
        while(true)
        {
            if (!(i.IsInList(ListOfIntegers)))
            {
                return i;
            }
            i++;
        }
        return maxResult;
    }
