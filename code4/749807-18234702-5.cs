    public string this[int n]
    {
       get
       {
           int current = 0;
           foreach (var prop in typeof(WineCellar).GetProperties())
           {
              if (current == n)
                 return prop.GetValue(this, null).ToString();
              current++;
           }
           return null;
       }
    }
