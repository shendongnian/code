    public static bool Contains(this string[] array)
    {
       foreach(var s in array)
       {
          if(s == View08ListBoxItem.Value.ToString())
          {
             return true;
          }
     
       }
      return false;
    }
