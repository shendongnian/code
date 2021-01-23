     public IList<YourResultModel> CallDb( )
     {
          return ( from item in GetJoinedView( )
                   select Mapper.MapTo<JoinedDataModel, YourResultModel>( item ) 
                 ).ToList( );
     }
