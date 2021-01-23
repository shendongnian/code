    public static string ProcessIT(object employeeDts1, string val)
    {
          // cast object to concrete type, assuming collection is IEnumerable here
          // but obviously only you know what the type is
          var KvpCollection = employeeDts1 As IEnumerable<KeyValuePair<string,string>>;
          if (KvpCollection == null) 
            {
               // bad data, you better handle it and not carry on
            }
          foreach (var keyValuePair in KvpCollection)
          {
            // do something to each of your keyValuePair objects ...
          }
    }
