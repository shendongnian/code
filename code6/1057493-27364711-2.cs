        /// <summary>
        /// Convert an array to a csv row, of the form "1,2,3,4.."
        /// </summary>
        /// <typeparam name="T">The array type</typeparam>
        /// <param name="list">The array</param>
        /// <returns>A comma delimited string</returns>
        public static string ToCSVRow<T>(this T[] list)
        {
            return string.Join(",", list);
        }
        /// <summary>
        /// Convert a jagged array to csv table, where each row has the form "1,2,3,.."
        /// </summary>
        /// <param name="array">The array of numbers</param>
        /// <returns>A string value</returns>
        public static string ToCSV<T>(this T[][] array)
        {
            return string.Join(Environment.NewLine, array.Select((row) => string.Join(",", row)));
        }
