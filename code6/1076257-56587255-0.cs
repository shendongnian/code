    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            gridApartment.DataSource = masterManager.GetAllRooms();
            gridApartment.DataBind();
        }
    }
  
