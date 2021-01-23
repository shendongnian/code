     int groupByCol = 1; //Change the value of this field according to the field you want to group by
      
     var GenericGroupsQuery = from t in Jobs                                          
                                 group t by new { GroupCol = ( groupByCol == 1 ? t.Industry:(groupByCol == 2 ? t.Field:(groupByCol == 3 ? t.Position : t.Job)))} into g
                                 select new 
                                 { 
                                    Tag = g.Key,
                                    Count = g.Count()
                                 };
          
