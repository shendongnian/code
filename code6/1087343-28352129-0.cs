    using( var context = new DryTypeEntities())
    {
        var result = context.Table_Products.Where(p => p.Code == 3).Select(p => p.Value) ;            
        foreach (var r in result)
        {
            double price = Convert.ToDouble(r);
            // There is no quatity returned by your query
        }
    }
