    private static void Addparms(SqlCommand cmd, object parms)
    {
      // parameter objects take the form new { propname = "value", ... } 
      foreach (PropertyInfo prop in parms.GetType().GetProperties())
      {
        cmd.Parameters.AddWithValue("@" + prop.Name, prop.GetValue(parms, null));
      }
    }
