    Session["id"] = TextBox1.Text;// just the username</pre>
        
         page 2(Default2.aspx) in page load 
            protected void Page_Load(object sender, EventArgs e)
            {
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Cache.SetExpires(DateTime.Now.AddDays(-1));
                Response.Cache.SetNoStore();
                
                    if (Session["id"] == null)
                    {    
                        
                        Response.Redirect("Default.aspx");// redirects to page1(default.aspx)
        
                    }
                    else
                    {
                        Label1.Text = (string)Session["id"];//just display user name in label
        
                    }
                
            }
