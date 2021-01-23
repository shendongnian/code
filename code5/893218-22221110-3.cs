    if (string.IsNullOrEmpty(txt1.Text) ||string.IsNullOrEmpty( txt2.Text) || string.IsNullOrEmpty(txt3.Text) || string.IsNullOrEmpty(txt4.Text))
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
