        /// <summary>
        /// Take a value from a the selected row of a DataGrid
        /// ATTENTION : The column's index is absolute : if the DataGrid is reorganized by the user,
        /// the index must change
        /// </summary>
        /// <param name="dGrid">The DataGrid where we take the value</param>
        /// <param name="columnIndex">The value's line index</param>
        /// <returns>The value contained in the selected line or an empty string if nothing is selected</returns>
        public static string getDataGridValueAt(DataGrid dGrid, int columnIndex)
        {
            if (dGrid.SelectedItem == null)
                return "";
            string str = dGrid.SelectedItem.ToString(); // Take the selected line
            str = str.Replace("}", "").Trim().Replace("{", "").Trim(); // Delete useless characters
            if (columnIndex < 0 || columnIndex >= str.Split(',').Length) // case where the index can't be used 
                return "";
            str = str.Split(',')[columnIndex].Trim();
            str = str.Split('=')[1].Trim();
            return str;
        }
        /// <summary>
        /// Take a value from a the selected row of a DataGrid
        /// </summary>
        /// <param name="dGrid">The DataGrid where we take the value.</param>
        /// <param name="columnName">The column's name of the searched value. Be careful, the parameter must be the same as the shown on the dataGrid</param>
        /// <returns>The value contained in the selected line or an empty string if nothing is selected or if the column doesn't exist</returns>
        public static string getDataGridValueAt(DataGrid dGrid, string columnName)
        {
            if (dGrid.SelectedItem == null)
                return "";
            for (int i = 0; i < columnName.Length; i++)
                if (columnName.ElementAt(i) == '_')
                {
                    columnName = columnName.Insert(i, "_");
                    i++;
                }
            string str = dGrid.SelectedItem.ToString(); // Get the selected Line
            str = str.Replace("}", "").Trim().Replace("{", "").Trim(); // Remove useless characters
            for (int i = 0; i < str.Split(',').Length; i++)
                if (str.Split(',')[i].Trim().Split('=')[0].Trim() == columnName) // Check if the searched column exists in the dataGrid.
                    return str.Split(',')[i].Trim().Split('=')[1].Trim();
            return str;
        }
