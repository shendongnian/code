        IDictionary<string, Tuple<object, object>> GetDifferentProperties<T>(T keyValue1, T keyValue2)
        {
           var diff = new Dictionary<string, object>();
           foreach (var prop in typeof(T).GetProperties(BindingFlags.Public))
           {
              var prop1Value = prop.GetValue(keyvalue1);
              var prop2Value = prop.GetValue(keyValue2);
              if (prop1Value != prop2Value)
                diff.Add(prop.Name, Tuple.Create(prop1Value, prop2Value));
           }
           return diff;
        }
         
