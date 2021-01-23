    using System.Data;
    public static class DataTableExtensionMethods
    {
        public static DataTable TransposeIntegerColumnIntoColumns(this DataTable dt, int indexColumnToEstablishDuplicateRows, int integerColumnIdToTranspose, string transposedColumnName)
        {
            //Protection if the column to transpose is not an integer
            var columnDataType = dt.Columns[integerColumnIdToTranspose].DataType;
            if (columnDataType != typeof(int)) return null;
    
            //Get max sessions number
            int maxColumnNumber = 0;
            foreach (DataRow dr in dt.Rows)
            {
                int number = dr.Field<int>(integerColumnIdToTranspose);
                maxColumnNumber = Math.Max(maxColumnNumber, number);
            }
    
            //Protection if there are zero rows or the maxColumnNumber is 0
            if (dt.Rows.Count == 0 || maxColumnNumber == 0) return null;
    
            //Make a copy of the table so we can remove duplicate rows and add the transposed columns
            DataTable result = dt.Copy();
    
            //Add columns to store the session_ids
            for (int i = 1; i <= maxColumnNumber; i++)
            {
                DataColumn dc = new DataColumn(transposedColumnName + i.ToString(), typeof(int));
                dc.DefaultValue = 0;
                //Possibly make an overloaded method that supports inserting columns
                result.Columns.Add(dc);
            }
    
            //Remove rows with duplicated employees
            for (int i = 0; i < result.Rows.Count; i++)
            {
                int duplicateRow = GetRowIndexById(result, indexColumnToEstablishDuplicateRows, result.Rows[i][indexColumnToEstablishDuplicateRows].ToString(), i + 1);
                if (duplicateRow > -1)
                {
                    result.Rows.RemoveAt(duplicateRow);
                }
            }
    
            //Populate the transposed columns with values in the integerColumnIdToTranspose
            foreach (DataRow dr in dt.Rows)
            {
                int sessionNumber = dr.Field<int>(integerColumnIdToTranspose);
                int rowIndex = GetRowIndexById(result, indexColumnToEstablishDuplicateRows, dr[indexColumnToEstablishDuplicateRows].ToString());
                result.Rows[rowIndex][transposedColumnName + sessionNumber.ToString()] = 1; //or +=1 if you want to increment the number
            }
    
            //Remove the integerColumnIdToTranspose (again overload this method if you want to keep this column)
            result.Columns.RemoveAt(integerColumnIdToTranspose);
    
            return result;
        }
    
        private static int GetRowIndexById(DataTable dt, int indexColumnToEstablishDuplicateRows, string id, int startLookAtRow = 0)
        {
            for (int i = startLookAtRow; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i][indexColumnToEstablishDuplicateRows].ToString() == id) return i;
            }
            return -1;
        }
    }
