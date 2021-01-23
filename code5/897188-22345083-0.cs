    if (r.Read())
    {
         if (SCO.State != ConnectionState.Closed) SCO.Close();
         r.Close();
               
    }
    // other code
    return true;
