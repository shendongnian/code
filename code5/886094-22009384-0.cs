    if (!IsPostBack)
    {
         if (Request.QueryString["id"] != null)
         {
             string catid = Request.QueryString["id"].ToString();
             Query1 = "select senderfirstname from messages where senderid='" + catid + "'";
             adap = new SqlDataAdapter(Query1, con);
             adap.Fill(ds);
             DataTable dt = ds.Tables["messages"];
           
             if (dt.Rows.Count > 0)
             {
                  DataRow dr = dt.Rows[0];
                  Session["table"] = dr["senderfirstname"].ToString();       
             }
             else
             {
                Label1.Text = "error";
             }
        }
    }
