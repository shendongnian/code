    using (SqlConnection con = new SqlConnection("your connection string")){
      con.Open();
    
      for (int i = 0; i < dgv_compare.Rows.Count; i++)
      {
         if (!DBCommands.sp_app_RatePlanDetail_Add(
                    con,
                    CarrierID,
                    ...
      };
    
      con.Close();
    }
