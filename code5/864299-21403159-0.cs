    public string DisplayDateTime(object value)
    {
      if (value== null)
      {
         return "Date is null";
      }
    
      return Convert.ToDateTime(value).ToShortDateString();
    }
