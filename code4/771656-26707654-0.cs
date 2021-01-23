    public static class Extensions
    {
        /// <summary>
        /// Truncate a value if it is a string.
        /// </summary>
        /// <param name="value">The value to check and truncate.</param>
        /// <param name="length">The length to truncate to.</param>
        /// <param name="appendEllipses">Append ellipses to the end of the value?</param>
        /// <returns>A truncated string, if not a string the object value.</returns>
        public static object Truncate(this object value, int length, bool appendEllipses = true)
        {
            // Are we dealing with a string value?
            var result = value as string;
            // Yes? truncate, otherwise pass through.
            return result != null ? Truncate(result, length, appendEllipses) : value;
        }
        /// <summary>
        /// Truncate a value if it is a string.
        /// </summary>
        /// <param name="value">The value to check and truncate.</param>
        /// <param name="length">The length to truncate to.</param>
        /// <param name="appendEllipses">Append elipses to the end of the value?</param>
        /// <returns></returns>
        public static string Truncate(this string value, int length, bool appendEllipses = true)
        {
            var result = value;
            // Too Long?
            if (value.Length > length)
            {
                // Truncate.
                result = value.Substring(0, length);
                // Add Ellipses, if needed.
                if (appendEllipses) { result = result + " ..."; }
            }
            return result;
        }
    }
