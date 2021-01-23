    public static class Extensions {
        public static T Coalesce<T>( this T self, T valueIfDefault ) {
            return self.Equals( default(T) ) ? valueIfDefault : self;
        }
    }
