    public ActionResult Index()
    {
      List<BillingValidation> list = new List<BillingValidation>();
      try
      {
        // runs stored procedure and returns data to main page
        using (SqlConnection con = new SqlConnection())
        {
          String sql = @"yourquery";
          con.ConnectionString = @"yourconnection"
          DataTable dt = new DataTable();
          SqlDataAdapter da = new SqlDataAdapter();
          da.SelectCommand = new SqlCommand(sql, con);
          da.Fill(dt);
          foreach (DataRow row in dt.Rows)
          {
            var bilVal = new BillingValidation();
            bilVal.Total = row["Total"].ToString();
            bilVal.Section = row["Section"].ToString();
            bilVal.Details = row["Details"].ToString();
            list.Add(bilVal);
          }
        }
        return View(list);
      }
    }
