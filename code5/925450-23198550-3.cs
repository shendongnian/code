    protected void btn_save(object sender,EventArgs e)
    {
     foreach(GridViewRow row in gv.Rows)
     {
       HiddenField hf = (HiddenField)row.FindControl("hfddl1Val");
       DropDownList ddl = (DropDownList)row.FindControl("ddl1");
       
       if(hf.Value != ddl.SelectedValue)
       {
          //save
       }
     }
    }
