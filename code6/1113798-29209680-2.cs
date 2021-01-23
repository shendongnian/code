    @model IEnumerable<IDisplayItem>
    
    @{
        var items = Model != null ? Model.ToList() : new List<IDisplayItem>();
        var itemsCount = items.Count;
    }
    
    @for (int i = 0; i < itemsCount; i++)
    {
        @items[i].DisplayValueFn()
        if (i < itemsCount - 1)
        {
            <text> | </text>
        }
    }
