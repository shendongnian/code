     protected void Page_Load(object sender, EventArgs e)
     {
         if(!IsPostBack)
         {
              Substance_Master.Attributes["CurrentSortField"] = "Substance_ID";
              Substance_Master.Attributes["CurrentSortDirection"] = "ASC";
              BindGridViewData();
         }
     }
