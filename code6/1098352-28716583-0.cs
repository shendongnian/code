     DataSet ds = new DataSet();
     SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["YourConnectionstrin"].ToString());
     string spName= "StoreProcedureName";
     SqlCommand cmd = new SqlCommand(spName, con);
     cmd.CommandType = CommandType.StoredProcedure;
     SqlDataAdapter da = new SqlDataAdapter(cmd);
     da.Fill(ds);
     if (ds != null)
     {
          gvList.DataSource = ds;
          gvList.DataBind();
     }
     else
     {
          gvList.DataSource = null;
          gvList.DataBind();
     }
