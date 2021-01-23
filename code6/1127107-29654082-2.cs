    public static class StringExtension
    {
        /// <summary>
        /// Returns a string array of the original string broken apart by the parameters
        /// </summary>
        /// <param name="str">The original string</param>
        /// <param name="obj">Integer array of how long each broken piece will be</param>
        /// <returns>A string array of the original string broken apart</returns>
        public static string[] ParseFormat(this string str, params int[] obj)
        {
            int startIndex = 0;
            string[] pieces = new string[obj.Length];
            for (int i = 0; i < obj.Length; i++)
            {
                if (startIndex + obj[i] < str.Length)
                {
                    pieces[i] = str.Substring(startIndex, obj[i]);
                    startIndex += obj[i];
                }
                else if (startIndex + obj[i] >= str.Length && startIndex < str.Length)
                {
                    // Parse the remaining characters of the string
                    pieces[i] = str.Substring(startIndex);
                    startIndex += str.Length + startIndex;
                }
    
                // Remaining indexes, in pieces if they're are any, will be null
            }
    
            return pieces;
        }
    }
