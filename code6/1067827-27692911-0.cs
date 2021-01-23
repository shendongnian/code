    protected void btnSave_Click(object sender, EventArgs e)
                {
    
                   for (int a = 1; a <= int.Parse(ddlUserSelected.SelectedItem.Text); a++)
                    {              
                         string value = Request.Form["txtDate" + a];
                    }
    
                }
