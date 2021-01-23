    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["admin"] == null)
                Response.Redirect("Login.aspx");
            else
            {
                lblAdmin.Text = "Welcome " + Session["admin"].ToString();
    
                ddlHotel.Items.Clear();
                ddlHotel.Items.Add(new ListItem("Select Hotel", ""));
                ddlHotel.AppendDataBoundItems = true;
                ddlHotel.DataSource = bll.getHotel();
                ddlHotel.DataTextField = "HName";
                ddlHotel.DataValueField = "HotelID";
                ddlHotel.DataBind();    
        
                if (Session["hotelID"] == null)
                    ddlHotel.SelectedIndex = 0;
                else
                    ddlHotel.SelectedValue = Session["hotelID"].ToString();
                ddlHotel_SelectedIndexChanged(null,null);
            }
        }
    }
        
    protected void ddlHotel_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlCategory.Items.Clear();
        ddlCategory.Items.Add(new ListItem("Select Category", ""));
        ddlCategory.AppendDataBoundItems = true;
        ddlCategory.DataSource = bll.getCategoryByID(ddlHotel.SelectedValue);
        ddlCategory.DataTextField = "RCategoryNameBed";
        ddlCategory.DataValueField = "RCategoryID";
        ddlCategory.DataBind();
    }
