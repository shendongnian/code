    protected void btnSignin_Click(object sender, EventArgs e)
    {
     int errorid;
     objBll = new bll();
     if(objBll.verifyUserCredentials(txtSignInUsername.Text,txtSignInPassword.Text, out errorid))
           {          
                Session["Username"]=txtSignInUsername;
                Response.Redirect("Default.aspx");
            }
           else 
             {
               //Else part code
             }
    }
