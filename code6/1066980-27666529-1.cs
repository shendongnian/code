    if (steel.HasValue) 
    {
        query = query.Where(b => b.SteelCode == steel.Value)
    }
    else 
    {
        query = query.Where(b => b.SteelCode == null)
    }
