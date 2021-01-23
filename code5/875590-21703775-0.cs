    public IEnumerable<TResult> Join<TOuter, TInner, TKey, TResult>(
        this IEnumerable<TOuter> outer,
        IEnumerable<TInner> inner,
        Func<TOuter, TKey> outerKeySelector,
        Func<TInner, TKey> innerKeySelector,
        Func<TOuter, TInner TResult> resultSelector)
    {
         var lookup = inner.ToLookup(innerKeySelector); // iterate over list2
         foreach(var outerItem in outer)
         {
              var joined = lookup[outerKeySelector(outerItem)]; // quick search
              if (!joined.Any())
                  continue; // go to next outer item if no matches exist
              foreach(var joindeItem in joined) // iterate over matches
                  yield return resultSelector(outerItem, joinedItem); // return index
         }
    }
