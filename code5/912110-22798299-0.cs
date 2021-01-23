        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var name = actionContext.ActionDescriptor.ActionName;
            // Get the sender address
            var myRequest = ((HttpContextWrapper)actionContext.Request.Properties["MS_HttpContext"]).Request;
            var ip = myRequest.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (!string.IsNullOrEmpty(ip))
            {
                string[] ipRange = ip.Split(',');
                int le = ipRange.Length - 1;
                string trueIP = ipRange[le];
            }
            else
            {
                ip = myRequest.ServerVariables["REMOTE_ADDR"];
            }
            // Log the call
            SystemBL.InsertSiteLog("WebAPI:" + name, "From:" + ip);
        }
