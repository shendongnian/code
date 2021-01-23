    refere this code  
    protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                    bindgrid();
    
                }
            }
    
            void bindgrid()
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select DISTINCT Class from addmitionform1", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                con.Close();
                ddlclass.DataSource = ds;
                ddlclass.DataTextField = "Class";
                ddlclass.DataValueField = "Class";
                ddlclass.DataBind();
                ddlclass.Items.Insert(0, new ListItem("--Select--", "0"));
       
            }
    
    protected void ddlKlasse_SelectedIndexChanged(object sender, EventArgs e)
        {
              string id = (ddlclass.SelectedValue.ToString());
                con.Close();
                SqlDataAdapter da1 = new SqlDataAdapter("Select id,FirstName from addmitionform1 where Class= '" + id + "'", con);
                //SqlDataAdapter da1 = new SqlDataAdapter("Select * from addmitionform1 ", con);
                DataSet ds1 = new DataSet();
                da1.Fill(ds1);
                GridView1.DataSource = ds1;
                GridView1.DataBind();
        }
