        if (Session["value"] != null)
        {
            Label1.Text = Session["value"].ToString();
        }
        else {
            Label1.Text = "Sorry,Please enter the value  ";
        }
    }
}
