    static void TreeWalk( IList list , StringBuilder buffer , Action<int,object,StringBuilder> visitNode , int? index )
    {
      // Enforce the contract's preconditions
      if ( list      == null ) throw new ArgumentNullException( "list"      ) ;
      if ( buffer    == null ) throw new ArgumentNullException( "buffer"    ) ;
      if ( visitNode == null ) throw new ArgumentNullException( "visitNode" ) ;
      
      // write the lead-in curly brace, prefixed with the optional index
      if ( index.HasValue )
      {
        buffer.Append( index.Value ).Append( " : ") ;
      }
      buffer.Append( "{"  ) ;
      
      // visit each direct child
      for ( int i = 0 ; i < list.Count ; ++i )
      {
        // write the item separator
        if ( i > 0 )
        {
          buffer.Append( " , " ) ;
        }
        
        // get the current child
        object child = list[i] ;
        
        // if the child is null, we skip it
        if ( child == null ) continue ;
        
        // if the child is a [nested] IList, we recursively visit it
        if ( child is IList ) {  TreeWalk( (IList)child , buffer , visitNode ) ; }
        
        // if the child is anything else, it's data: just visit it
        visitNode( i , child , buffer ) ;
        
      }
      
      // write the lead-out curly brace
      buffer.Append( " }" ) ;
      
      return ;
    }
