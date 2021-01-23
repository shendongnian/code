    static List<int> FilterMod3Internal(List<int> state, List<int> initialList, int index)
    {
        if (index >= initialList.Count())
        {
            return state;
        }
        else
        {
            var number = initialList[index];
            if (number%3 == 0)
            {
                state.Add(number);
                        
            }
    
            return FilterMod3Internal(state, initialList, index + 1);
        }
    }
    static List<int> FilterMod3(List<int> list)
    {
        return FilterMod3Internal(new List<int>(), list, 0);
    }
