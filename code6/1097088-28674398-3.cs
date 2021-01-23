    public static class Foo {
    
        public static Tuple<T2,T1> Reverse<T1,T2> (this Tuple<T1,T2> tuple) {
            return new Tuple<T2,T1>(tuple.Item2,tuple.Item1);
        }
    
    }
