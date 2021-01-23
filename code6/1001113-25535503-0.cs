    var commonItems = from x in list1
                      join y in list2
                      where regex.Match(x.Value).Success                  
                      //do x.Value.Replace("$(", "")
                      Let x1 = x.Value.Replace("$(", "")
                      //do x.Value.Replace(")", "")
                      Let x2 = x1.Value.Replace(")", "")
                      //then call
                      on x2.Value equals y.Name
                      select new { Item = x, NewValue = y.Value };
    
    foreach (var x in commonItems)
    {
        x.Item.Value = x.NewValue;
    }
