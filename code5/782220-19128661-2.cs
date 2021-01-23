    public static class Extensions {
        public static bool Empty<T>( this IEnumerable<T> l, 
                Func<T,bool> predicate=null ) {
            return predicate==null ? !l.Any() : !l.Any( predicate );
        }
    }
