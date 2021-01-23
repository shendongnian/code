    SqlConnection db = new SqlConnection("ConnectionStringHere");
          SqlTransaction transaction;
      db.Open();
      transaction = db.BeginTransaction();
      try 
      {
        var SqlC1= new SqlCommand("SP1", db, transaction);
		<Add parameters in SqlC1>
            SqlC1.ExecuteNonQuery();
	    var SqlC2= new SqlCommand("SP2", db, transaction);
		<Add parameters in SqlC2>
            SqlC2.ExecuteNonQuery();
			
         var SqlC3= new SqlCommand("SP3", db, transaction);
		<Add parameters in SqlC3>
            SqlC3.ExecuteNonQuery();
         transaction.Commit();
      } 
      catch (SqlException sqlError) 
      {
         transaction.Rollback();
      }
      db.Close();**strong text**
