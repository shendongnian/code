    public static string ProcessIT(object employeeDts1, string val)
    {
          // cast object to concrete type
          var KvpCollection = employeeDts1 As IEnumerable<KeyValuePair<string,string>>;
          if (KvpCollection == null) return; // bad data
          foreach (var keyValuePair in KvpCollection)
          {
            KeyValuePair<string, string> txt = new KeyValuePair<string, string>();
            txt = keyValuePair ;
            if (txt!=null)
            {
                //here I process that object...
            }
          }
    }
