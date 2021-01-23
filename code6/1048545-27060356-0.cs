    private string _tel;
    public string Tel 
    {
      set{ _tel = value; }
      get {
        return _tel.PutStars();
      }
    }
    
    public static string PutStars(this string str)
    {
     return str.Replace("1", "*");
    }
