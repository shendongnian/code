        protected void Page_Load(object sender, EventArgs e)
        {
            cataloguesRepeater.ItemCreated += cataloguesRepeater_ItemCreated;
            cataloguesRepeater.DataSource =  new [] { new { title = "item1"}, new { title = "item2" } };
            cataloguesRepeater.DataBind();
        }
        void cataloguesRepeater_ItemCreated(object sender, RepeaterItemEventArgs e)
        {            
           if (e.Item.ItemType == ListItemType.Footer)
           {
               var ddl = e.Item.FindControl("dropDownList1");
           }            
        }
