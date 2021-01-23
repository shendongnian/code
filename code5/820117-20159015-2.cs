    customers
        .AsParallel()
        .SelectMany(c => {
            var context = GetContextForCustomer(c);
            if (someCondition)
                return myData.Select(x => new { CustomerID = c, X1 = x.x1, X2 = x.x2 });
            else
                return Enumerable.Empty<dynamic>();
           })
        .ToList();
