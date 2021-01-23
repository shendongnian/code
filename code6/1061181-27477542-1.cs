    public void Button1_Click(object sender, System.EventArgs e) 
    {
            if(sender)
            Response.Redirect("HomePage.aspx?eid={0}", sno);
    }
