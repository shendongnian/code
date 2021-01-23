    if (items.GetType().GetInterface("System.Collections.Generic.ICollection`1") != null)
    {
        dynamic dynamic = items;
        return dynamic.Count;
    }
