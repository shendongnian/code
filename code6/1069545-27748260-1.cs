        protected override void OnInit(System.EventArgs e)
        {
             Response.AddHeader("Refresh",Convert.ToString((Session.Timeout * 60) + 5));      
             if(Session.IsNewSession)  
                Response.Redirect(“Logout.aspx”);// or another page which you want.
        }
