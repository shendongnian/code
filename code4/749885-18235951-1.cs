    public static bool Contains(this string[] array, string value)
    {
       foreach(var s in array)
       {
          if(s == value)
          {
             return true;
          }
     
       }
      return false;
    }
    ProfileArray.Contains(View08ListBoxItem.Value.ToString());
