        //Global asax handlers   
        public override void Init() {
            base.Init();
            // handlers managed by ASP.Net during Forms authentication
            BeginRequest += new EventHandler(BeginRequestHandler);
          //  PostAuthorizeRequest += new EventHandler(PostAuthHandler);
            EndRequest += new EventHandler(EndRequestHandler);
        }
       
