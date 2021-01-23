    public List<MyType> ParseTable(DataTable dt) {
       var myTypes = new List<MyType>();
       var dictionary = new Dictionary<string, List<List<string>>>();
    
       foreach(DataRow dr in dt.Rows) {
          var name = dr[0];
          var time = dr[1];
          var status = dr[2]; 
          if(!dictionary.ContainsKey(dr[0]) {
            dictionary[name] = new List<List<string>>();
          }
    
          dictionary[name].Add(new List<string>{time, status});
       }
       foreach(var key = dictionary.Keys) {
          myTypes.Add(new MyType {Name = key, Data = dictionary[key]});
       }
       return myTypes;
    }
