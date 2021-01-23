    ...
    public static Singleton Instance
    {
         get
         {
             if (_Instance == null)         
             {
                 _Instance = new Singleton();
                 Application.Exit += (sender, args) =>
                 {
                     _Instance.SaveChanges();
                 }
             }
    
             return _Instance;
         }
    }
