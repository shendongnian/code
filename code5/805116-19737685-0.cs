    static void Main( string[] args )
    {
      List<Color> colorList1 = Enum.GetValues(typeof(Colors)).Cast<Colors>().Select( c => new Color( c.ToString(), (int)c ) ).ToList() ;
      List<Color> colorList2 = Enum.GetNames(typeof(Colors)).Zip( Enum.GetValues(typeof(Colors)).Cast<int>() , (n,v)=> new Color(n,v)).ToList() ;
      return ;
    }
    class Color
    {
      public Color( string name , int value )
      {
        Name = name ;
        Value = value ;
      }
      public string Name { get ; set ;  }
      public int    Value { get ; set ; }
      public override string ToString()
      {
        return string.Format( "{0}:{1}" , Name , Value ) ;
      }
    }
    enum Colors
    {
      Red    = 1 ,
      Orange = 2 ,
      Yellow = 3 ,
      Green  = 4 ,
      Blue   = 5 ,
      Indigo = 6 ,
      Violet = 7 ,
    }
