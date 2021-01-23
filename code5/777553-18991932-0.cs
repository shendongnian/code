    public static void CustomSort<T>( this IList<T> list , IComparer<T> comparer )
    {
      int[]            unsorted = Enumerable.Range(0,list.Count).ToArray() ;
      int[]            sorted   = ((IEnumerable<int>)unsorted).OrderBy( x => list[x] , comparer ).ToArray() ;
      Tuple<int,int>[] deltas   = sorted
                                  .Zip( unsorted , (x,y)=> Tuple.Create(x,y) )
                                  .Where( x => x.Item1 != x.Item2 )
                                  .OrderBy( x => x.Item1 )
                                  .ToArray()
                                  ;
      
      // At this point, 'delta' is an array of tuples/2, each of which indicates a move.
      // The first item in the tuple is the offset of the item item in the ordered list
      // The second item in the tuple is the offset of the item in the original, unordered list
      //
      // Basically, each tuple is an instruction for a move
      
      // Now, we iterate over th set of deltas in the sorted order, moving each unsorted item into its new position.
      Dictionary<int,T> scratchPad = new Dictionary<int, T>() ; // a parking lot for incomplete moves
      foreach ( Tuple<int,int> delta in deltas )
      {
        int sortedIndex   = delta.Item1 ;
        int unsortedIndex = delta.Item2 ;
        
        if ( sortedIndex < unsortedIndex )
        {
          // if the sorted index is less than the unsorted index, we need
          // to park the existing, unordered item in the sorted position
          // in the scratchpad, so it can be fetched later, when it needs
          // to move into its new, ordered position.
          scratchPad.Add( sortedIndex , list[sortedIndex]);
          list[sortedIndex] = list[unsortedIndex] ;
        }
        else if ( sortedIndex > unsortedIndex )
        {
          // if the sorted index is greated than the unordered index,
          // that means that we need to fetch that item from the scratchpad,
          // since its slot in the original list already contains an ordered item
          list[sortedIndex] = scratchPad[unsortedIndex];
          scratchPad.Remove( unsortedIndex );
        }
        else // sortedIndex == unsortedIndex
        {
          // since we discarded tuples where the sorted and unsorted indices are the same,
          // this can't happen: throw the appropriate exception.
          throw new InvalidOperationException();
        }
      }
      
      return ;
    }
