        var p1 = GetProducts();  
        var res =p1
                .GroupBy(p => p.CategoryID)
                .Where(g => g.Count() >= 3)
                .SelectMany(g => g.CategoryName);
