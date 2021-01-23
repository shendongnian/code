    protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
           
         if (e.CommandName == "YourCommandName")
                {
                    r1 = (RadioButton)e.Item.FindControl("rdButton");
                 }
       }
