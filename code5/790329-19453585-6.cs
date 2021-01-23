        public R Match<R>(Func<T, R> f1, Func<U, R> f2)
        {
            if (_item1Set)
            {
                return f1(this.Item1);
            }
            else if (_item2Set)
            {
                return f2(this.Item2);
            }
            else
            {
                throw new InvalidOperationException("Variant not set");
            }
        }
