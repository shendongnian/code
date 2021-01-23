    protected void Page_Load(object sender, EventArgs e)
    {
         if(session["role"].ToString().compareTo("admin")==0)
         {
         //load page stuff
         }
         else
         {
             Response.Redirect(your login page);
         }
    }
  
    
