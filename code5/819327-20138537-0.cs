    for (int i = 0; i < YourGridViewID.Rows.Count; i++)
    {
 
     GridViewRow row = YourGridView.Rows[i];
     bool isChecked = ((CheckBox) row.FindControl("yourCheckBoxID")).Checked;
    
      if (isChecked)
      {
        Response.Write((string)this.YourGridViewID.DataKeys[i]["yourColumnDataKey"];);
      }
    }
