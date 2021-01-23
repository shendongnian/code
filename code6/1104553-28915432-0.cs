    IQueryable<MyModel> q = new List<MyModel>().AsQueryable(); // this is just an example, this is obviously not a list
    
          IQueryable<object> query = from item in q select (object)new { item.Property };
    
          var oneItem = query.FirstOrDefault(x => ((dynamic)x).SomeProperty == somevalue);
          object[] allItems = query.ToArray();
 
