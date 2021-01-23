    bool dictionariesEqual = Dict.Keys.Count == Dict_Aggregate.Keys.Count 
        && Dict.Keys.All(k => Dict_Aggregate.ContainsKey(k) 
        && Dict_Aggregate.All(v => 
          { int test; 
            return int.TryParse(v.Value, out test) 
              && Dict[v.Key].Equals(test); });
