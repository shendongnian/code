    public static class MyStackExtensions
    {
        public static Stack<TDest> Convert<TSrc, TDest>(
            this Stack<TSrc> stack, 
            Func<TSrc, TDest> converter = null)
        {
            if (stack == null)
                throw new ArgumentNullException("stack");
            var items = converter == null
                ? stack.Select(i => (TDest) System.Convert.ChangeType(i, typeof (TDest)))
                : stack.Select(converter);
            return new Stack<TDest>(items.Reverse());
        }
    }
