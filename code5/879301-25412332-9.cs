    public static class Extensions
    {
        public static R Fun<S,T>(this B<S> self, A<T> arg) where S : T
        {
            return self.Perform(new TheFun<T> { arg = arg });
        }
    }
