    public static class Int64Key
    {
        /// <summary>
        ///     The minimum supported value.
        /// </summary>
        public const long MinValue = long.MinValue + 1;
        /// <summary>
        ///     The maximum supported value.
        /// </summary>
        public const long MaxValue = long.MaxValue;
        // Mapping tables to convert to/from original Base64 and the sortable variant
        private static readonly char[] B2S = new char[123];
        private static readonly char[] S2B = new char[123];
        static Int64Key()
        {
            // Base-64 alphabet
            const string B64 = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/";
            // Alternative with natural (ordinal) sort order
            const string S64 = "-0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ_abcdefghijklmnopqrstuvwxyz";
            // Populate mapping tables B2S and S2B
            for (int i = 0; i < 64; ++i)
            {
                B2S[B64[i]] = S64[i];
                S2B[S64[i]] = B64[i];
            }
        }
        /// <summary>
        ///     Encodes the specified integer key to its string representation.
        /// </summary>
        public static string Encode(long value)
        {
            // Check that value is within the supported range
            // Only "long.MinValue" is unsupported.
            if (value == long.MinValue)
            {
                throw new ArgumentOutOfRangeException();
            }
            
            long abs = Math.Abs(value);           
            byte[] data = BitConverter.GetBytes(abs);
            // Make sure data is big endian
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(data);
            }
            // Get Base-64 representation
            char[] arr = new char[13];
            Convert.ToBase64CharArray(data, 0, 8, arr, 1);
            // Convert from Base-64 alphabet to the sortable variant
            // Also, count the number of leading 'A' chars. (those will be omitted)
            int numA = 0;
            bool atA = true;
            for (int i = 1; i < 12; ++i)
            {
                if (atA)
                {
                    if (arr[i] == 'A')
                    {
                        ++numA;
                    }
                    else
                    {
                        atA = false;
                    }
                }
                arr[i] = B2S[arr[i]];
            }
            // Prepend the appropriate flag character
            string tab = value <= 0 ? "ABCDEFGHIJKZ" : "kjihgfedcba";
            arr[numA] = tab[numA];
            // Create and return key string
            return new string(arr, numA, 12 - numA);
        }
        /// <summary>
        ///     Decodes the specified string key to its integer representation.
        /// </summary>
        public static long Decode(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                throw new ArgumentException();
            }
            // Interpret flag character. It tells us the number of omitted 'A' chars and whether
            // the value is positive or negative.
            char f = str[0];
            int numA;
            bool neg;
            if (f >= 'A' && f <= 'K')
            {
                numA = f - 'A';
                neg = true;
            }
            else if (f >= 'a' && f <= 'k')
            {
                numA = 'k' - f;
                neg = false;
            }
            else if (f == 'Z')
            {
                numA = 11;
                neg = false;
            }
            else
            {
                throw new ArgumentException();
            }
            char[] arr = new char[12];
            int pos;
            // Prepend the number of omitted 'A' chars
            for (pos = 0; pos < numA; ++pos)
            {
                arr[pos] = 'A';
            }
            // Convert from the sortable alphabet to the original Base-64 alphabet
            for (int i = 1; i < str.Length; ++i, ++pos)
            {
                arr[pos] = S2B[Math.Min(122, (int)str[i])];
            }
            // Always append Base-64 padding character
            arr[11] = '=';
            // Parse Base-64
            byte[] data = Convert.FromBase64CharArray(arr, 0, 12);
            // Data is always in big endian, so we might need to swap back to little endian.
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(data);
            }
            // Get value from bits
            long value = BitConverter.ToInt64(data, 0);
            // Negate it if needed
            return neg ? -value : value;
        }
    }
