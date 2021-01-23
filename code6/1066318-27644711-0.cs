    string CS = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
    using(SqlConnection con = new SqlConnection(CS))
    using(SqlCommand cmd = new SqlCommand("SELECT top(1) num from loan where id=@str", con))
    {
        cmd.Parameters.Parameters.Add("@str",SqlDbType.NVarChar).Value = id;
        cmd.CommandType = CommandType.Text;
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);
        no = ds.Tables[0].Rows[0]["num"].ToString();
        return Json(new
            {
             no = no
            }, JsonRequestBehavior.AllowGet);
    }
