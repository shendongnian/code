     public static IQueryable<D> ReturnDTO<D>(this IQueryable<BaseObjectWithDTO> query)
        where D : BaseDTO, new()
     {
        if(query == null) throw new ArgumentNullException("query");
     if( !typeof(BaseObjectWithDTO<D,int>) .IsAssignableFrom(query.GetType().GetGenericParameters()[0])) 
              throw new ArgumentOutOfRangeException("query");
        //expression tree code to convert
     }
