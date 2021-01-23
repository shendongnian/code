        /// <summary>
        /// Displays the column headers
        /// </summary>
        /// <returns>returns an array of column widths</returns>
        private static int[] DisplayHeaders(string[] headers)
        {
            // builds a new int array with the same 
            // number of elements as the string array parameter
            int[] widths = new int[headers.Length];
            for (int i = 0; i < headers.Length; i++)
                widths[i] = headers[i].Length; // populates the array with the string sizes
            // the return keyword instructs the program to send the variable 
            // that follows back to the code that called this method
            return widths; 
        }
