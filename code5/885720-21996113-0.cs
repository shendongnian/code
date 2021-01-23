        /// <summary>
        /// Allows the use of type inference to get selector functions for the type of an enumerable.
        /// </summary>
        /// <typeparam name="T">The type of the enumerable.</typeparam>
        /// <param name="enumerable">The enumerable.</param>
        /// <param name="selectors">A set of selectors to return.</param>
        /// <returns>The selectors passed in.</returns>
        public static Func<T, Object>[] GetSelectors<T>(
            IEnumerable<T> enumerable,
            params Func<T, Object>[] selectors)
        {
            return selectors;
        }
