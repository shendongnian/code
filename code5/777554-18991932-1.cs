    public static void CustomSort<T>( IList<T> list , IComparer<T> comparer )
    {
      int[] unsorted = Enumerable.Range(0,list.Count).ToArray() ;
      int[] sorted   = Enumerable.Range(0,list.Count).OrderBy( x => list[x] , comparer ).ToArray() ;
      var   moves    = sorted.Zip( unsorted , (x,y) => new{ Src = x , Dest = y , } ).Where( x => x.Src != x.Dest ).OrderBy( x => x.Src ).ToArray() ;
      // at this point, moves is a list of moves, from a source position to destination position.
      // We enumerate over this and apply the moves in order.
      // To do this we need a scratch pad to save incomplete moves, where an existing item has
      // been over-written, but it has not yet been moved into its final destination.
      
      Dictionary<int,T> scratchPad = new Dictionary<int, T>() ; // a parking lot for incomplete moves
      foreach ( var move in moves )
      {
        T value ;
        // see if the source value is on the scratchpad.
        // if it is, use it and remove it from the scratch pad.
        // otherwise, get it from the indicated slot in the list.
        if ( scratchPad.TryGetValue( move.Src , out value ) )
        {
          scratchPad.Remove( move.Src );
        }
        else
        {
          value = list[ move.Src ] ;
        }
        // if the destination is after the source position, we need to put
        // it on the scratch pad, since we haven't yet used it as a source.
        if ( move.Dest > move.Src )
        {
          scratchPad.Add( move.Dest , list[ move.Dest ]);
        }
        // finally, move the source value into its destination slot.
        list[ move.Dest ] = value ;
      }
      
      return ;
    }
