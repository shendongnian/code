      /// <summary>
        /// Returns an individual HTTP Header value
        /// </summary>
        /// <param name="headers"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetHeader(this HttpContentHeaders headers, string key, string defaultValue)
        {
            IEnumerable<string> keys = null;
            if (!headers.TryGetValues(key, out keys))
                return defaultValue;
            return keys.First();
        }
