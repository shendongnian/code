    private DataTable TransposeNumericColumnIntoColumns(this DataTable dt, int indexColumnToEstablishDuplicateRows, int numericColumnIdToTranspose, string transposedColumnName)
    {
        //TODO Add Protection here if the column to transpose is not numeric
        //Get max sessions number
        int maxColumnNumber = 0;
        foreach (DataRow dr in dt.Rows)
        {
            int number = dr.Field<int>(numericColumnIdToTranspose);
            maxColumnNumber = Math.Max(maxColumnNumber, number);
        }
        //TODO Add Protection here if there are zero rows or the maxColumnNumber is 0
    
        //Make a copy of the table so we can remove duplicate rows and add the transposed columns
        DataTable result = dt.Copy();
    
        //Add columns to store the sessions
        for (int i = 1; i <= maxColumnNumber; i++)
        {
            DataColumn dc = new DataColumn(transposedColumnName + i.ToString(), typeof(int));
            dc.DefaultValue = 0;
            result.Columns.Add(dc);
        }
    
        //Remove rows with duplicated employees
        for (int i = 0; i < result.Rows.Count; i++)
        {
            int duplicateRow = GetRowIndexById(result, indexColumnToEstablishDuplicateRows, result.Rows[i][indexColumnToEstablishDuplicateRows].ToString(),i + 1);
            if (duplicateRow > -1)
            {
                result.Rows.RemoveAt(duplicateRow);
            }
        }
    
        //Populate the session_id's columns depending on the value in the session_id column
        foreach (DataRow dr in dt.Rows)
        {
            int sessionNumber = dr.Field<int>(numericColumnIdToTranspose);
            int rowIndex = GetRowIndexById(result, indexColumnToEstablishDuplicateRows, result.Rows[i][indexColumnToEstablishDuplicateRows].ToString());
            result.Rows[rowIndex][transposedColumnName + sessionNumber.ToString()] = 1; //or +=1 if you want to increment the number
        }
    
        //Remove the session_id column
        result.Columns.RemoveAt(numericColumnIdToTranspose);
        return result;
    }
    
    private int GetRowIndexById(DataTable dt, int indexColumnToEstablishDuplicateRows, string id, int startLookAtRow = 0)
    {
        for (int i = startLookAtRow; i < dt.Rows.Count; i++)
        {
            if (dt.Rows[i][indexColumnToEstablishDuplicateRows].ToString() == id) return i;
        }
        return -1;
    }
    private void button1_Click(object sender, EventArgs e)
    {
        DataTable dtOriginal = new DataTable();
        dtOriginal.Columns.Add("emp_num", typeof(int));
        dtOriginal.Columns.Add("name");
        dtOriginal.Columns.Add("status", typeof(int));
        dtOriginal.Columns.Add("session_id",typeof(int));
    
        DataRow dr = dtOriginal.NewRow();
        dr["emp_num"] = 22;
        dr["name"] = "John";
        dr["status"] = 0;
        dr["session_id"] = 4;
        dtOriginal.Rows.Add(dr);
    
        dr = dtOriginal.NewRow();
        dr["emp_num"] = 22;
        dr["name"] = "John";
        dr["status"] = 0;
        dr["session_id"] = 5;
        dtOriginal.Rows.Add(dr);
    
        dr = dtOriginal.NewRow();
        dr["emp_num"] = 22;
        dr["name"] = "Moh";
        dr["status"] = 1;
        dr["session_id"] = 3;
        dtOriginal.Rows.Add(dr);
    
        dr = dtOriginal.NewRow();
        dr["emp_num"] = 22;
        dr["name"] = "Ran";
        dr["status"] = 0;
        dr["session_id"] = 3;
        dtOriginal.Rows.Add(dr);
    
        dr = dtOriginal.NewRow();
        dr["emp_num"] = 22;
        dr["name"] = "Ran";
        dr["status"] = 0;
        dr["session_id"] = 4;
        dtOriginal.Rows.Add(dr);
        DataTable result = TransposeNumericColumnIntoColumns(dtOriginal, 0, 3, "session_id");
    
    }
    
