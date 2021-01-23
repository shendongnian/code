    class T
    {
        public string SomeProp 
        {
            get
            {
                //Some complicated logic
            }
        }
    }
    
    class Y
    {
        public string SomeProp {get; set;}
    }
    //Some initiation code somewhere else in your project
    public static void InitializeMappings()
    {
        Mapper.CreateMap<T, Y>();
    }
    public static IQueryable<Y> FilterOnTAndMapToY(IQueryable<T> source, Expression<Func<T,bool>> filter)
    {
          return source.Where(filter).Project().To<Y>();
    }
  
