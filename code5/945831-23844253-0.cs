    if(user.loginsuccess) {
        Session["UserName"]=user.username.ToString();
        
       // Gets a reference to a Label control that not in a ContentPlaceHolder
       Label mpLabel = (Label) Master.FindControl("HeadLoginName");
       if(mpLabel != null)
          Label1.Text = user.username; 
    }
