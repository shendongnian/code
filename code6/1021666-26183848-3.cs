    protected void Page_Load(object sender, EventArgs e)
        {
        if(!IsPostBack)
            {
            var myData=GetData(); //should return some type of ICollection representing your data to bind to
            ControlsRepeater.DataSource=myData;
            ControlsRepeater.DataBind();
            }
        }
