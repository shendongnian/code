        string pw = txtPassword.Text;
        string pwa = txtPasswordAgain.Text;
        
        if (string.IsNullOrEmpty(pw) && string.IsNullOrEmpty(pwa))
        {
          lblPWCountAgain.Visible=false;
    //whicheverLabelIsShowing.Text = "Whatever text you want showing";
        }    
        else if (pw == pwa)
        {
          lblPWCountAgain.Visible=true;
          lblPasswordCount.Text = "Passwords Match";
          lblPWCountAgain.Text = "Passwords Match";
        } 
        else
        {
          lblPWCountAgain.Visible = true;
          lblPWCountAgain.text = "Passwords do not match!";
          var passw = txtPassword.MaxLength - txtPassword.Text.Length;
          lblPasswordCount.Text = passw.ToString();
        }
    
    // I also just tried to use this as well
    if (pw == "" && pwa == "")
    {
      lblPWCountAgain.Visible = false;
    
      var passw = txtPassword.MaxLength - txtPassword.Text.Length;
      lblPasswordCount.Text = passw.ToString();
    }
