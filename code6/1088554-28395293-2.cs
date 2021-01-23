    private static string conStr = @".....";
    public void insertRecord()
    {
        using(SqlConnection myCon = new SqlConnection(conStr))
        using(SqlCommand insertInfo = new SqlCommand("spInsertStudentInformation", myCon))
        {
            myCon.Open();
            insertInfo.CommandType = CommandType.StoredProcedure;
            ....
            insertInfo.ExecuteNonQuery();
 
            // No need to close the connection here....
            SqlCommand insertData = new SqlCommand("spInsertStudentData", myCon);
            insertData.CommandType = CommandType.StoredProcedure;
            ....
            insertData.ExecuteNonQuery();
        }
    }
