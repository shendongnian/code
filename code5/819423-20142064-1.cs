      static IEnumerator<string> everyOther( IEnumerable<string> collection )
      {
        var e = collection.GetEnumerator();
        while( e.MoveNext() ) {
          yield return e.Current;
          e.MoveNext(); //skip one
        }
      }
