            string email = txtEmail.Text;
            string date = txtDate.Text;
            string time = txtTime.Text;
            string name = txtName.Text;
            
            Session["email"] = email;
            Session["date"] = date;
            Session["time"] = time;
            Session["name"] = name;
            Response.Redirect("~/change.aspx");
