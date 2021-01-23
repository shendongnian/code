    //assuming something like.... 
           public override void Init() {
            base.Init();
            
            // handlers managed by ASP.Net during Forms authentication
            
            PostAuthorizeRequest += new EventHandler(PostAuthHandler);
          
        }
   
    // try screen out some calls that arent authenticated yet.
    public void PostAuthHandler(object sender, EventArgs e) {
             if (Request.IsAuthenticated) {
             //.... try a break to see how often 
             }
        }
