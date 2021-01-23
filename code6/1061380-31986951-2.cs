     public void Configuration(IAppBuilder app)
        {
            // Any connection or hub wire up and configuration should go here           
            try
            {
                app.Use(SetMyPrincipalObject);
            }
        }
      private Task SetMyPrincipalObject(IOwinContext arg1, Func<Task> arg2)
        {
            //var p = "Process response";//Process Response Header here and //create identity
            //arg1.Request.User = p;
            //return arg2.Invoke();
        }
 
