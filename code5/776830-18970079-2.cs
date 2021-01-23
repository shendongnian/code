    public T min( )
    {
        T tempItem = list[0];
        for (int i = 0; i < length; i++)
        {
            if (list[i].CompareTo(tempItem) < 0)
            {
                tempItem = list[i];
            }
        }
        return tempItem;
    }
