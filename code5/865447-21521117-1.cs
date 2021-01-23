    protected void ods_Updating(object sender, ObjectDataSourceMethodEventArgs e)
    {
        if(e.CommandName=="Update")
         GridViewRow row = (GridViewRow)ods.Rows[e.RowIndex];
         LinkButton lnkBtn = (LinkButton)row.FindControl("LinkButton1");
        //I would like to accomplish something like
          // if (lnkBtn.Enabled == true)
             if (lnkBtn.Text == "Enabled")
               {
                    //Do your stuff .
               }
    //    e.InputParameters["value"] = isItEnabled ? 0 : 1;
    }
