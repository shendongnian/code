    //
    ///<summary>Create an array of a derived class from a list of a base class. Array elements may be null, if the cast was not possible.</summary>
    public static D[] ToArray<T, D>( this IList<T> list ) where D : class {
        if ( !list.IsFilled() ) return null;
        var a = new D[ list.Count ];
        for ( int i = 0; i < list.Count; i++ ) {
            a[ i ] = list[ i ] as D;
        }
        return a;
    }
