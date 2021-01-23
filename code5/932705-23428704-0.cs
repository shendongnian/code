     protected void Page_Load(object sender, EventArgs e)
        {
          if (!IsPostBack)
            {
             InstanceData = (DataSet)(Session["InstanceData"]);
             id1.DataSource = InstanceData.tables[0];
             id1.DataTextField = "DB";
             id1.DataValueField = "DB";
             id1.DataBind();
            }
        }
     protected void Button1_Click(object sender, EventArgs e)
        {
            string DataBase = id1.SelectedValue;
        }
