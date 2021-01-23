    var modelList = new List<MyCourseData>();
    string batchid = System.Web.HttpContext.Current.Request.QueryString["batchid"];
    SqlConnection con = null;
    string result = "";
    DataSet ds = null;
    con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString());
    SqlCommand cmd = new SqlCommand("select * from [Student].[dbo].[tbl_batch] where batchid=@batchid", con);
    //cmd.CommandType = CommandType.StoredProcedure;
    cmd.Parameters.AddWithValue("@batchid", batchid);
    con.Open();
    SqlDataAdapter da = new SqlDataAdapter();
    da.SelectCommand = cmd;
    ds = new DataSet();
    da.Fill(ds);
    con.Close();
    for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
    {
        
        var classdates = ds.Tables[0].Rows[i]["class_dates"].ToString();
        int j = 0;
       // string[] parts = classdates.Split(',');
         foreach (string CourseDates in classdates.Split(','))
         {
            var model = new MyCourseData();                  
            model.batchid = ds.Tables[0].Rows[i]["batchid"].ToString();
            model.course = ds.Tables[0].Rows[i]["course"].ToString();
            model.trainer = ds.Tables[0].Rows[i]["trainer"].ToString();
            model.class_dates = CourseDates;
            modelList.Add(model);
         }
    }
    return modelList;
    }
