    private void Page_Load(object sender, System.EventArgs e){      
        Response.AddHeader("Refresh",Convert.ToString((Session.Timeout * 60) + 5));      
        if(Session[“IsUserValid”].ToString()==””)              
        Server.Transfer(“Relogin.aspx”);
    }
 
 
