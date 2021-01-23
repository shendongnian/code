    protected void Page_Load(object sender, EventArgs e)
    {
       if (!this.IsPostBack)
       {
          // db query and create checkboxlist and other
          SqlConnection dbConn = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnString"].ConnectionString);
          string query;
          try
          {
            query = "SELECT [name], [mail] FROM [users]";
            dbConn.Open();
            SqlDataAdapter da = new SqlDataAdapter(query, dbConn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count != 0)
            {
              checkboxlist1.DataSource = ds;
              checkboxlist1.DataTextField = "name";
              checkboxlist1.DataValueField = "mail";
              checkboxlist1.DataBind();
            }
            else
            {
              Response.Write("No Results found");
            }
           }
           catch (Exception ex)
           {
              Response.Write("<br>" + ex);
           }
           finally
           {
              dbConn.Close();
           }
       }
    }
    protected void btnSend_Click(object sender, EventArgs e)
     {
       string strChkBox = string.Empty;
       foreach (ListItem li in checkboxlist1.Value)
        {
          if (li.Selected == true)
           {
             strChkBox += li.Value + "; ";    
             // use only   strChkBox += li + ", ";   if you want the name of each checkbox checked rather then it's value.
           }
        }
       Response.Write(strChkBox);
     }
              
