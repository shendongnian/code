        /// <summary>
        /// Convert an array to string list, of the form "1,2,3,.."        
        /// </summary>
        /// <param name="array">The array of numbers</param>
        /// <returns>A string value</returns>
        public static string ToCSVRow<T>(this T[] array)
        {
            string[] parts=new string[array.Length];
            for(int i=0; i<parts.Length; i++)
            {
                parts[i]=array[i].ToString();
            }
            return string.Join(",", parts);
        }
        /// <summary>
        /// Convert a jagged array to csv table, where each row has the form "1,2,3,.."
        /// </summary>
        /// <param name="array">The array of numbers</param>
        /// <returns>A string value</returns>
        public static string ToCSV<T>(this T[][] array)
        {
            List<string> csv=new List<string>();
            for(int i=0; i<array.Length; i++)
            {
                csv.Add(array[i].ToCSVRow());
            }
            return string.Join(Environment.NewLine, csv.ToArray());
        }
