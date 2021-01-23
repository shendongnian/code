    protected void Page_Load(object sender, EventArgs e)
    {
        if(IsPostBack)
         {
           if(DropDownList1.SelectedIndex>0)
                DropDownList1.Items.FindByValue("-1").Enabled = false;
         }
    }
