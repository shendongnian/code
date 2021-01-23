           app.Use((owinContext, next) =>
            {          
                return next().ContinueWith(x =>
                {
                    if (owinContext.Response.StatusCode == 500 /*or 401 , etc*/)
                    {                        
                        owinContext.Response.Redirect(VirtualPathUtility.ToAbsolute("~/Home/Error"));
                    }
                });                
            });
