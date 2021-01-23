    if (txt1.Text == string.Empty || txt2.Text == string.Empty || txt3.Text == string.Empty || txt4.Text == string.Empty)
        {
           string script = "<script type=\"text/javascript\">alert('Please enter values');</script>";
           ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script);
           Button1.Enabled = false;
            return false;
        }
        else
        {
            Button1.Enabled = true;
        }
    
     
    }
   
