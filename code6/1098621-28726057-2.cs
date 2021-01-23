    static void FilterListMod3Internal(List<int> list, int index)
    {
        if (index >= list.Count())
        {
            return;
        }
    
        var number = list[index];
    
        if (number%3 != 0)
        {
            list.RemoveAt(index);
            FilterListMod3Internal(list, index);
        }
        else
        {
            FilterListMod3Internal(list, index + 1);
        }
    }
