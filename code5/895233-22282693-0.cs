    public static IEnumerable<T> Interleave<T>( IEnumerable<IEnumerable<T>> sequences )
    {
        var enumerators = sequences.Select( s => s.GetEnumerator() ).ToArray();
        while ( true )
        {
            foreach ( var e in enumerators )
            {
                if ( e.MoveNext() )
                {
                    yield return e.Current;
                }
                else
                {
                    yield break;
                }
            }
        }
    }
