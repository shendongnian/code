            Session.Abandon();
            Response.Redirect("Default.aspx");
        }
        else
        {
            if ((Session["User"] == null) || (Session["project"] == null))
            {
                Session["project"] = Label1.Text;
                Session["User"] = Label2.Text;
            }
            if ((Label1.Text == "Label") || (Label2.Text == "Label"))
            {
                Label1.Text = Session["project"].ToString();
                Label2.Text = Session["User"].ToString();
            }
        }
