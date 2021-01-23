    private DataTable TransposeSessionIDValueIntoColumns(DataTable dt, int sessionCol)
    {
        //Get max sessions number
        int maxSessions = 0;
        foreach (DataRow dr in dt.Rows)
        {
            int sessionNumber = dr.Field<int>(sessionCol);
            maxSessions = Math.Max(maxSessions, sessionNumber);
        }
    
        //Make a copy of the table so we can remove duplicate rows and add the sessions
        DataTable result = dt.Copy();
    
        //Add columns to store the sessions
        for (int i = 1; i <= maxSessions; i++)
        {
            DataColumn dc = new DataColumn("session_id" + i.ToString(), typeof(int));
            dc.DefaultValue = 0;
            result.Columns.Add(dc);
        }
    
        //Remove rows with duplicated employees
        for (int i = 0; i < result.Rows.Count; i++)
        {
            int duplicateRow = GetRowIndexById(result, 0, Convert.ToInt32(result.Rows[i][0]),i + 1);
            if (duplicateRow > -1)
            {
                result.Rows.RemoveAt(duplicateRow);
            }
        }
    
        //Populate the session_id's columns depending on the value in the session_id column
        foreach (DataRow dr in dt.Rows)
        {
            int sessionNumber = dr.Field<int>(sessionCol);
            int rowIndex = GetRowIndexById(result, 0, Convert.ToInt32(dr[0]));
            result.Rows[rowIndex]["session_id" + sessionNumber.ToString()] = 1; //or +=1 if you want to increment the number
        }
    
        //Remove the session_id column
        result.Columns.Remove("session_id");
    
        return result;
    }
    
    private int GetRowIndexById(DataTable dt, int idColumn, int id, int startLookAtRow = 0)
    {
        for (int i = startLookAtRow; i < dt.Rows.Count; i++)
        {
            if (Convert.ToInt32(dt.Rows[i][idColumn]) == id) return i;
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
        DataTable result = TransposeSessionIDValueIntoColumns(dtOriginal, 3);
    
    }
    
