    public class IntList
    {
         public int Item { get; set; }
    }
    var list1 = new List<IntList>{new IntList{ Item= 1 }, new IntList{ Item= 2}};
    var list2 = new List<IntList>{new IntList{ Item= 3 }, new IntList{ Item= 4}};
    
    var parameters = new DynamicParameters();
    parameters.Add("@Keyword", "stringValue");
    parameters.AddTable("@CategoryIds", "IntList", list1);
    parameters.AddTable("@MarketIds", "IntList", list2);
    
     var result = con.Query<int>("someSP", parameters, commandType: CommandType.StoredProcedure);
