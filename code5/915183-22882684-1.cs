    int? a = (int?)null;
    int? b = (int?)null;
    
    try
    {
        Console.WriteLine(a.Value + b.Value);
    }
    catch (Exception ex)
    {
        ex.Data.Add("a", a);
        ex.Data.Add("b", a);
    
        throw;
    }
