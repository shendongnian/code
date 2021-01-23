    protected void Page_Load(object sender, EventArgs e)
    {
         if(ddlcolumn.SelectedValue == "All")
         {
              txtsearch.Attributes.Add("disabled","disabled");
         }
         else
         {
              txtsearch.Attributes.Remove("disabled");
         }
    }
