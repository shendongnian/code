    public static class StringExt
    {
        /// <summary>
        /// Returns the first <paramref name="count"/> characters of a string, or the entire string if it
        /// is less than <paramref name="count"/> characters long.
        /// </summary>
        /// <param name="self">The string. Cannot be null.</param>
        /// <param name="count">The number of characters to return.</param>
        /// <returns>The first <paramref name="count"/> characters of the string.</returns>
        
        public static string Left(this string self, int count)
        {
            Contract.Requires(self != null);
            Contract.Requires(count >= 0);
            Contract.Ensures(Contract.Result<string>() != null);
            // ReSharper disable PossibleNullReferenceException
            Contract.Ensures(Contract.Result<string>().Length <= count);
            // ReSharper restore PossibleNullReferenceException
            if (self.Length <= count)
                return self;
            else
                return self.Substring(0, count);
        }
        /// <summary>
        /// Returns the last <paramref name="count"/> characters of a string, or the entire string if it
        /// is less than <paramref name="count"/> characters long.
        /// </summary>
        /// <param name="self">The string. Cannot be null.</param>
        /// <param name="count">The number of characters to return.</param>
        /// <returns>The last <paramref name="count"/> characters of the string.</returns>
        public static string Right(this string self, int count)
        {
            Contract.Requires(self != null);
            Contract.Requires(count >= 0);
            Contract.Ensures(Contract.Result<string>() != null);
            // ReSharper disable PossibleNullReferenceException
            Contract.Ensures(Contract.Result<string>().Length <= count);
            // ReSharper restore PossibleNullReferenceException
            if (self.Length <= count)
                return self;
            else
                return self.Substring(self.Length - count, count);
        }
    }
