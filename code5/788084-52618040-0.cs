    public static class StringExtensions
    {
        /// <summary>
        /// Extends the <code>String</code> class with this <code>ToFixedString</code> method.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="length">The prefered fixed string size</param>
        /// <param name="appendChar">The <code>char</code> to append</param>
        /// <returns></returns>
        public static String ToFixedString(this String value, int length, char appendChar = ' ')
        {
            string current = value;
            int currlen = current.Length;
            int needed = length == currlen ? 0 : (length - currlen);
            return needed == 0 ? value :
                (needed > 0 ? value + new string(' ', needed) :
                    new string(new string(value.ToCharArray().Reverse().ToArray()).
                        Substring(needed * -1, value.Length - (needed * -1)).ToCharArray().Reverse().ToArray()));
        }
    }
