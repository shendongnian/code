    static DateTime ConvertToDateTime(string str)
    {
      if (string.IsNullOrEmpty(str))
        throw new ArgumentNullException();
    
      return DateTime.Parse(str);
    }
