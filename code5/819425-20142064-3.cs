      static IEnumerable<T> everyOther<T>( IEnumerable<T> collection )
      {
        using( var e = collection.GetEnumerator() ) {
          while( e.MoveNext() ) {
            yield return e.Current;
            e.MoveNext(); //skip one
          }
        }
      }
