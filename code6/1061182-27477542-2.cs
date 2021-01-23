    public void Button1_Click(object sender, System.EventArgs e) 
    { 
            string sno = lnkEdit.CommandArgument;
            if(sender)
            Response.Redirect("HomePage.aspx?eid=" + sno);
    }
