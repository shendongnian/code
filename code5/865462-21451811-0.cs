    if (dtChanges != null)
    {
        using(var objConn = new SqlConnection(strConn))
        {
            objConn.Open();
            for (int i = 0; i < dtChanges.Rows.Count; i++)
            {
                long? patientid = (long?)dtChanges.Rows[i]["patientid"]; // you must return the id in your sql to distinguish a needed INSERT from an UPDATE
                if (!patientid.HasValue) 
                {
                    using (var objCmd = objConn.CreateCommand())
                    {
                        objCmd.CommandText = "INSERT INTO Patient(pFirstName) VALUES(@pFirstName); SELECT SCOPE_IDENTITY();";
                        objCmd.Parameters.AddWithValue("@pFirstName", (string)dtChanges.Rows[i]["pFirstName"]);
                        patientid = (long)objCmd.ExecuteScalar();
                    }                            
                }
                else
                {
                    using (var objCmd = objConn.CreateCommand())
                    {
                        objCmd.CommandText = "UPDATE Patient SET pFirstName = @pFirstName WHERE patientid = @patientid";
                        objCmd.Parameters.AddWithValue("@pFirstName", (string)dtChanges.Rows[i]["pFirstName"]);
                        objCmd.Parameters.AddWithValue("@patientid", patientid);
                        objCmd.ExecuteNonQuery();
                    }
                }
                
                using (var objCmd = objConn.CreateCommand())
                {
                    objCmd.CommandText = "UPDATE APPOINTMENT SET aDate = @date, aStatus = @status, patientid = @patientid WHERE appointmentID = @appointmentID";
                    objCmd.Parameters.AddWithValue("@date", (DateTime)dtChanges.Rows[i]["aDate"]);
                    objCmd.Parameters.AddWithValue("@status", (string)dtChanges.Rows[i]["aStatus"]);
                    objCmd.Parameters.AddWithValue("@patientid", patientid);
                    objCmd.Parameters.AddWithValue("@appointmentID", (long)dtChanges.Rows[i]["appointmentID"]);
                    objCmd.ExecuteNonQuery();
                }
           }
      }
}
