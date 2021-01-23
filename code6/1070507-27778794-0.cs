    protected void btnSave_Click(object sender, EventArgs e)
    {
        Context1.sp_CreateUserTest(txtName.Text, txtEmail.Text, txtMobile.Text, DateTime.Parse(txtBirthdate.Text)); 
     
     txtName.Text = String.Empty;
     txtEmail.Text= String.Empty;
     txtMobile.Text= String.Empty;
     txtBirthdate.Text= String.Empty;
    
        grdvUsers.DataBind(); 
    }
