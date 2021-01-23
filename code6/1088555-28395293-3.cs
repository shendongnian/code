        using(SqlConnection myCon = new SqlConnection(conStr))
        using(SqlCommand insertInfo = new SqlCommand("spInsertStudentInformation", myCon))
        {
            myCon.Open();
            using(SqlTransaction ts = myCon.BeginTransaction())
            {
               insertInfo.CommandType = CommandType.StoredProcedure;
               insertInfo.Transaction = ts;
               ....
               insertData.CommandType = CommandType.StoredProcedure;
               insertData.Transaction = ts;
               ....
               insertData.ExecuteNonQuery();
               ts.Commit();
           }
        }
