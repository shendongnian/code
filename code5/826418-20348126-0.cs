    public static class GenericExtensions
    {
        /// <summary>
        /// Throws an ArgumentNullException if "this" value is default(T)
        /// </summary>
        /// <typeparam name="T">(Inferred) "this" type</typeparam>
        /// <param name="self">"this" value</param>
        /// <param name="variableName">Name of the variable</param>
        /// <returns>"this" value</returns>
        /// <exception cref="System.ArgumentException">Thrown if "this" value is default(T)</exception>
        public static T ThrowIfDefault<T>(this T self, string variableName)
        {
            if (EqualityComparer<T>.Default.Equals(self, default(T)))
                throw new ArgumentException(string.Format("'{0}' cannot be default(T)", variableName));
            return self;
        }   // eo ThrowIfDefault<T>    
    }
