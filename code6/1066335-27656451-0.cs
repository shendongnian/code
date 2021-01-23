    SqlConnection conobj=new SqlConnection;
    SqlCommand cmdobj=new SqlCommand(""Select BATSMAN_NAME from RUNS_STATS", conobj);
    SQlDataAdapter sdaobj=new SqlDataAdapter(cmdobj);
    DataTable dtobj=new DataTable();
    sdaobj.Fill(dtobj);
    GridView2.DataSource=dtobj;
    GridView2.DataBind();
