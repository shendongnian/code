     protected void btnRegister_Click(object sender, EventArgs e)
     { 
         //...      
         int iReturnCode = obj.empReg(txtUserName.Text, txtPassword.Text, isactive);
         //if(iReturnCode > 0)
         Response.Redirect("~/Login.aspx");                                        
     }
