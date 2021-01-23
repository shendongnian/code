    public static class StringExtensions
    {
        public static IEnumerable<string> SplitLazy(this string value, params char[] separator)
        {
            return value.SplitLazy(int.MaxValue, StringSplitOptions.None, separator);
        }
        public static IEnumerable<string> SplitLazy(this string value, StringSplitOptions options, params char[] separator)
        {
            return value.SplitLazy(int.MaxValue, options, separator);
        }
        public static IEnumerable<string> SplitLazy(this string value, int count, params char[] separator)
        {
            return value.SplitLazy(count, StringSplitOptions.None, separator);
        }
        /// <summary>
        /// Splits a string into substrings that are based on the characters in an array. 
        /// </summary>
        /// <param name="value">The string to split.</param>
        /// <param name="options"><see cref="StringSplitOptions.RemoveEmptyEntries"/> to omit empty array elements from the array returned; or <see cref="StringSplitOptions.None"/> to include empty array elements in the array returned.</param>
        /// <param name="count">The maximum number of substrings to return.</param>
        /// <param name="separator">A character array that delimits the substrings in this string, an empty array that contains no delimiters, or null. </param>
        /// <returns></returns>
        /// <remarks>
        /// Delimiter characters are not included in the elements of the returned array. 
        /// If this instance does not contain any of the characters in separator the returned sequence consists of a single element that contains this instance.
        /// If the separator parameter is null or contains no characters, white-space characters are assumed to be the delimiters. White-space characters are defined by the Unicode standard and return true if they are passed to the <see cref="Char.IsWhiteSpace"/> method.
        /// </remarks>
        public static IEnumerable<string> SplitLazy(this string value, int count = int.MaxValue, StringSplitOptions options = StringSplitOptions.None, params char[] separator)
        {
            if (count == 0) yield break;
            Func<char, bool> predicate = char.IsWhiteSpace;
            if (separator != null && separator.Length != 0)
                predicate = (c) => separator.Contains(c);
            if (string.IsNullOrEmpty(value) || count == 1 || !value.Any(predicate))
            {
                yield return value;
                yield break;
            }
            bool removeEmptyEntries = (options & StringSplitOptions.RemoveEmptyEntries) != 0;
            int ct = 0;
            var sb = new StringBuilder();
            for (int i = 0; i < value.Length; ++i)
            {
                char c = value[i];
                if (!predicate(c))
                {
                    sb.Append(c);
                }
                else
                {
                    if (sb.Length != 0)
                    {
                        yield return sb.ToString();
                        sb.Clear();
                    }
                    else
                    {
                        if (removeEmptyEntries)
                            continue;
                        yield return string.Empty;
                    }
                    if (++ct >= count - 1)
                    {
                        if (removeEmptyEntries)
                            while (++i < value.Length && predicate(value[i]));
                        else
                            ++i;
                        if (i < value.Length - 1)
                        {
                            sb.Append(value, i, value.Length - i);
                            yield return sb.ToString();
                        }
                        yield break;
                    }
                }
            }
            if (sb.Length > 0)
                yield return sb.ToString();
            else if (!removeEmptyEntries && predicate(value[value.Length - 1]))
                yield return string.Empty;
        }
    }
