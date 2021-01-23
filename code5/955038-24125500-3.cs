    List<ComparisonData> cList = new List<ComparisonData>();
 
    while(reader.Read())
    {
       ComparisonData c = new ComparisonData();
    
       c.Tables.Add(reader.GetString(0));
       // other properties
    
       // since it is a List, just call the Add method and pass the object
       cList.Add(c);
    }
