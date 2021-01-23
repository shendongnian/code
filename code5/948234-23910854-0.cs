    protected void DropDownList1_DataBound(object sender, EventArgs e)
    {
       if(!IsPostBack){
         string selectedValue = Request.QueryString["catId"];
         if(!string.IsNullOrEmpty(selectedValue))
           DropDownList1.SelectedValue = selectedValue;
       }
    }
