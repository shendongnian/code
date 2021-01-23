    public static string ProcessIT(object employeeDts1, string val)
    {
          // cast object to concrete type
          var KvpCollection = employeeDts1 As IEnumerable<KeyValuePair<string,string>>;
          if (KvpCollection == null) 
            {
               // bad data, you better handle it and not carry on
            }
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
