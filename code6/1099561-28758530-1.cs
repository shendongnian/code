     SqlDataReader reader = cmd .ExecuteReader();
     DateTime? dateFromDB = null;
     while (reader.Read())
     {
       dateFromDB  = Convert.ToDateTime(reader["RestTime"]);
     }
     if(dateFromDB.HasValue)
      {
        if(DateTime.Now.TimeOfDay == dateFromDB.TimeOfDay
        {
          // time equal
        }
      }
