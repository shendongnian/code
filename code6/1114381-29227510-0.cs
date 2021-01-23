    string querySearch = " SELECT * FROM table "
    addConditionToQuery(querySearch, "age", textboxAge.text);
    addConditionToQuery(querySearch, "status", textboxStatus.text);
    ...
    
    void addConditionToQuery(string Query, string ColumnName, string Value) {
        if(!String.IsNullOrWhiteSpace(Value)) {
          if(Query.IndexOf("WHERE")>-1) {
            Query += "WHERE ";
          } else {
            Query += "AND ";
          }
            Query += ColumnName +" = '" + Value + "' ";
        }
    }
