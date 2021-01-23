    try
    {
      using (var cnnSQL = new SqlConnection(...))
      {
        using (var cmmSQL = new SqlCommand("nVision_select_lcimagelinks_sp", cnnSQL))
        {
          cmmSQL.CommandType = System.Data.CommandType.StoredProcedure;
          SqlParameter prmSQL = cmmSQL.Parameters.Add(new SqlParameter
          {
              ParameterName = "@LCIMGLINKUSERID",
              Value = userId
          });
          using (var rdrSQL = cmmSQL.ExecuteReader())
          {
          ...
          }
        }
      {
    } ...
