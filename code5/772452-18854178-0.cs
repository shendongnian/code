    public void PriorityUp(Item it)
    {
        if (DecreasePriority(it))
        {
            IncreaseOther(it.Priority, new[] { it });
        }
    }
    public void PriorityUp(IEnumerable<Item> items)
    {
        List<int> toDecrease = new List<int>();
        foreach (var item in items)
        {
            if (DecreasePriority(item))
            {
                toDecrease.Add(item.Priority);
            }
        }
        foreach(var p in toDecrease)
        {
            IncreaseOther(p, items);
        }
    }
    private bool DecreasePriority(Item it)
    {
        if(it.Priority <= 1)
        {
            return false;
        }
        it.Priority--;
        return true;
    }
    private void IncreaseOther(int priority, IEnumerable<Item> toIgnore)
    {
        foreach (var item in allItems.Values.Except(toIgnore))
        {
            if (item.Priority == priority)
            {
                item.Value.Priority++;
            }
        }
    }
