          protected void Page_Load(object sender, EventArgs e)
            {
        
                    if(!IsPostBack)
                    {
              string queryString = "select College_Name from Colleges";
        string   constring=System.Configuration.ConfigurationManager.ConnectionStrings["ConnDBForum"].ConnectionString;
                      
                    SqlConnection connection = new SqlConnection(constring);
                    SqlCommand command = new SqlCommand(queryString, connection);
                    connection.Open();
                    DataTable dt = new DataTable();
                    SqlDataAdapter ad = new SqlDataAdapter(command);
                    ad.Fill(dt);
        
                    if (dt.Rows.Count > 0)
                    {
                        DropDownList2.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                        DropDownList2.DataSource = dt;
                        DropDownList2.DataTextField = "College_Name";
                        DropDownList2.DataValueField = "College_Name";
                        DropDownList2.DataBind();
                        DropDownList2.Items.Insert(0, new ListItem(String.Empty, String.Empty));
    
                    }
     connection.Close();
                }
            }
