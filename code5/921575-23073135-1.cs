    class MyClassMap
    {
        MyClass[] backingStore ; // ordered by StartRange, then EndRange
        public MyClassMap( IEnumerable<MyClass> source )
        {
            backingStore.OrderBy( x => x.StartRange ).ThenBy( x => x.EndRange ) ;
        }
        public int? GetIdFromValue( long value )
        {
            int  lo = 0 ;
            int  hi = backingStore.Length ;
            int? ix = null ;
            while ( lo <= hi && !ix.HasValue )
            {
                int mid = lo + ((hi-lo)>>1) ;
                MyClass current = backingStore[mid] ;
                if      ( value > current.EndRange   ) { lo = mid+1      ; }
                else if ( value < current.StartRange ) { hi = mid-1      ; }
                else                                   { ix = current.Id ; }
            }
            return ix ;
        }
    }
