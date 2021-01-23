    public static bool Contains<T>(this T[] array, T value) where T : class
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
