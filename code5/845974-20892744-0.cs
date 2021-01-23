    public Hashtable GetData(Table table, string headerType)
    {
      var data = table.CreateSet<SpecFlowData>();
      var hashtable = new Hashtable(); // no need to clear a newly created Hashtable
      int i = 1;
      foreach (var currentRow in data)
      {
        var key = currentRow.FieldName;
        var value = GetValue(currentRow);
        if (hashtable.ContainsKey(key))
        {
            key = key + i++;
        }
        var format = (string)value["header"];
        if (headerType == format)
        {
          hashtable.Add(key, value);
        }
      }
      return hashtable;
    }
    private static Hashtable GetValue(SpecFlowData currentRow)
    {
      var value = new Hashtable();
      value.Add("code", currentRow.Code);
      value.Add("name", currentRow.FieldName);
      value.Add("header", currentRow.HeaderType);
    }
