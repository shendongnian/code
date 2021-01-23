        void Application_BeginRequest(object sender, EventArgs e)
        {
            if (ReferenceEquals(null, HttpContext.Current.Request.Headers["Authorization"]))
            {
                var token = HttpContext.Current.Request.Params["Authorization"];
                if (!String.IsNullOrEmpty(token))
                {
                    HttpContext.Current.Request.Headers.Add("Authorization", "Bearer " + token);
                }
            }
        }
