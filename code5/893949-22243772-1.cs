    public static class ObservableToINPCObject {
        public static ObservableToINPCObject<T> ToINPC<T>
            ( this IObservable<T> source, T init = default(T) )
            {
                return new ObservableToINPCObject(source, init);
            }
    }
    
