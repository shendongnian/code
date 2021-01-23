    public void stack(Loot source, Loot target)
    {
        var availableOnTarget = target.MaxCount - target.Count;
        var amountToStack = Math.Min(availableOnTarget, source.Count);
        target.Count += amountToStack;
        source.Count -= amountToStack;
        if(target.Count==target.MaxCount && source.Count > 0)
        {
            Inventory.Add(source); 
        }
    }
