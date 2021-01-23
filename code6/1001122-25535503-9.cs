            var q =  from x in list1
                     let x1 = x.Value.Replace("$(", "").Replace(")", "")
                    join y in list2 on x1 equals y.Name
                    select new { 
                        Item = x.Name, 
                        NewValue = x.Value != x1 ? y.Value: x.Value 
                    };
          
            foreach (var s in q)
            {
                Console.WriteLine(s.Item + " " + s.NewValue);
            }
    
