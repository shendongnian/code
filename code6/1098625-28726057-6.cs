    static void FilterListInternal<T>(List<T> list, int index, Func<T, bool> filterFunction)
    {
        if (index >= list.Count())
        {
            return;
        }
    
        var item = list[index];
    
        if (!filterFunction(item))
        {
            list.RemoveAt(index);
            FilterListInternal(list, index, filterFunction);
        }
        else
        {
            FilterListInternal(list, index + 1, filterFunction);
        }
    }
    
    static void FilterList<T>(List<T> list, Func<T, bool> filterFunction)
    {
        FilterListInternal<T>(list, 0, filterFunction);
    }
