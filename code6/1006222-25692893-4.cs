    myConnection.Open();
    var loArrayRegistrosCalendario = new List<Calendar>();
    using (SqlCommand sqlCommand = new SqlCommand(" SELECT * FROM table ", 
      myConnection);)
    {
      using (SqlDataReader dr = sqlCommand.ExecuteReader())
      {
        if (dr != null)
        {
          while (dr.Read())
          {
            Calendar loRegistroDia = new Calendar();
            loRegistroDia.User = (dr["user"].ToString());
  
            loArrayRegistrosCalendario.Add(loRegistroDia);
          }
        }
      }
    }
  
    return loArrayRegistrosCalendario;
