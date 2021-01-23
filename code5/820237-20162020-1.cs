    protected void LinkButton_Click(Object sender, EventArgs e) 
    {
       Session.Clear();
       Session.RemoveAll();
       Session.Abandon();
       Response.Redirect("Login.aspx"); 
     }
