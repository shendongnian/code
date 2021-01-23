            if(Request.Cookies["SessionId_"] != null)
            {
                Response.Cookies["SessionId_"].Expires = DateTime.Now.AddMilliseconds(-10);
            }
            else if(Request.Cookies["ASP.NET_SessionId"] != null)
            {
                Response.Cookies["ASP.NET_SessionId"].Expires = DateTime.Now.AddMilliseconds(-10);
            }
            Session.Abandon();
