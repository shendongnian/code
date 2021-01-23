    public string MyDataItem(object value)
    {
      if (string.IsNullOrEmpty(value.ToString()))
      {
         return "N/A";
      }
    
      return myValue.ToString();
    }
