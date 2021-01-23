    if (objds.Tables[0].Rows.Count > 0)
        //here in this place i need to compare with the columns of the objds dataset column ie..processID)
        {
            string columnValueFromFirstResultSet = ds.Tables[0].Rows[j]["COLUMNNAME"].ToString();
            for (int i = 0; i < objds.Tables[0].Rows.Count - 1; i++)
            {
                string columnValueOfFirstRow = objds.Tables[0].Rows[i]["COLUMNNAME"].ToString();
                if (columnValueFromFirstResultSet != columnValueOfFirstRow)
                {
                    //Do something
                }
            }
            string DeactivateDateTime = "null";
            i = db.ExecuteNonQuery("Insert INTO tblSeatAssignmentDetails Values(" + SeatAssignmentId + "," + ProcessID[j] + ",'" + DateTime.Now + "','1'," + DeactivateDateTime + ")");
        }
