    /// <summary>
    /// String extensions methods
    /// </summary>
    public static class StringExtensionsClass
    {
        /// <summary>
        /// Check if two strings has only one "difference"
        /// </summary>
        /// <param name="BaseString"></param>
        /// <param name="StringToCountDiff"></param>
        /// <returns></returns>
        public static bool HasOneDiff(this string BaseString, string StringToCountDiff)
        {
            int _diffCount = 0;
            if (BaseString.Length == StringToCountDiff.Length)
            {
                for (int i = 0; i < BaseString.Length; i++)
                {
                    if (BaseString[i] != StringToCountDiff[i])
                    {
                        _diffCount++;
                    }
                }
                if (_diffCount == 1)
                {
                    return true;
                }
            }
            return false;
        }
    }
