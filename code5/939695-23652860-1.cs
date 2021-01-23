        /// <summary>
    /// Factory class which creates an EqualityComparer based on lambda expressions.
    /// </summary>
    /// <typeparam name="T">The type of which a new equality comparer is to be created.</typeparam>
    public static class EqualityComparerFactory<T>
    {
        private class MyComparer : IEqualityComparer<T>
        {
            private readonly Func<T, int> _getHashCodeFunc;
            private readonly Func<T, T, bool> _equalsFunc;
            public MyComparer(Func<T, T, bool> equalsFunc, Func<T, int> getHashCodeFunc = null)
            {
                _getHashCodeFunc = getHashCodeFunc ?? (a=>0);
                _equalsFunc = equalsFunc;
            }
            public bool Equals(T x, T y)
            {
                return _equalsFunc(x, y);
            }
            public int GetHashCode(T obj)
            {
                return _getHashCodeFunc(obj);
            }
        }
        /// <summary>
        /// Creates an <see cref="IEqualityComparer{T}" /> based on an equality function and optionally on a hash function.
        /// </summary>
        /// <param name="equalsFunc">The equality function.</param>
        /// <param name="getHashCodeFunc">The hash function.</param>
        /// <returns>
        /// A typed Equality Comparer.
        /// </returns>
        public static IEqualityComparer<T> CreateComparer(Func<T, T, bool> equalsFunc, Func<T, int> getHashCodeFunc = null)
        {
            ArgumentValidator.NotNull(() => equalsFunc);
            return new MyComparer(equalsFunc, getHashCodeFunc);
        }
    }
