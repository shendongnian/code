    if (txt1.Text == "" || txt2.Text == "" || txt3.Text == "" || txt4.Text == "")
            {
               ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "scrip1", "alert('Enter All fields');", true);
            Button1.Enabled = false;
            }
            else
            {
                Button1.Enabled = true;
            }
