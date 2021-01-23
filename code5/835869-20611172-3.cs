     protected void Button1_Click(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedIndex == 1)
            {
                Session["room"] = "Deluxe Room";
                Label1.Text = "Classy Room";
                Label2.Text = "Good for you";
                Label3.Text = "100";
    
                Session["rom"] = Session["rom"] + "<br>" + DropDownList1.Text;
                Session["prc"] = Session["prc"] + "<br>" + Label3.Text;
                Session["img"] = Convert.ToString(Session["img"]) +  Image1.Imageurl + ",";
            }
            else if (DropDownList1.SelectedIndex == 2)
            {
    
                Session["room"] = "Deluxe Room";
                Label1.Text = "Nga-nga kayo";
                Label2.Text = "Good for me";
                Label3.Text = "100,000";
    
                Session["rom"] = Session["rom"] + "<br>" + DropDownList1.Text;
                Session["prc"] = Session["prc"] + "<br>" + Label3.Text;
                Session["img"] = Convert.ToString(Session["img"]) + Image1.Imageurl + ",";
    
            }
        }
