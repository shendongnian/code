    protected void btnClick_Click(object sender, EventArgs e)
    { 
        foreach (GridViewRow row in gridDepartments.Rows)         
        {             
            CheckBox chkSelItem = (CheckBox)row.FindControl("chkSelItem");
            Label lblSelectedItem= (Label)row.FindControl("lblSelectedItem");
    
            if (chkSelItem.Checked) 
            {
                int departmentId = int.Parse(lblSelectedItem.Text); 
            }
        }
    }
