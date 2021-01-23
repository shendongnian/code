           app.Use((owinContext, next) =>
            {          
                return next().ContinueWith(x =>
                {
                    if (owinContext.Response.StatusCode == 500 /*or 401 , etc*/)
                    {                        
                        //owinContext.Response.Redirect(VirtualPathUtility.ToAbsolute("~/Home/Error"));
                        //this should work for self-host as well
                        owinContext.Response.Redirect(owinContext.Request.Uri.AbsoluteUri.Replace(request.Uri.PathAndQuery, request.PathBase + "/Home/Error"));
                    }
                });                
            });
