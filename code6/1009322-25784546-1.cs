    var acceptable = ".,0,1,2,3,4,5,6,7,8,9"; // list of acceptable values
    var nums = acceptable.Split(',').Select(a=> a[0]); // get the chars
    using(var price = new pricingdemoEntities())
    {
      // You can limit this even further by adding a take or additional where clauses
      var query = price.demotables.Select(p => p.value).AsEnumerable();
      var money = query.Where(q=> q.value.All(c=> nums.Contains(c)).ToList();
    }
