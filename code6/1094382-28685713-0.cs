        var dbSets = ctx.GetType().GetProperties();
        foreach(var set in dbSets)
        {
            if(set.PropertyType.IsGenericType)
            {
                 method
        
