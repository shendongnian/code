    if (txt1.Text == string.Empty || txt2.Text == string.Empty || txt3.Text == string.Empty || txt4.Text == string.Empty)
            {
             string script = "alert('Please enter values');";
             ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script, true);
               Button1.Enabled = false;
                return false;
            }
            else
            {
                Button1.Enabled = true;
            }
        
         
        }
