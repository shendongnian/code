    [System.Web.Http.AcceptVerbs("POST")]
    public async Task<HttpResponseMessage> Register()
    {
        // Check if the request contains multipart/form-data.
        if (!Request.Content.IsMimeMultipartContent())
        {
            throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
        }
        string root = HttpContext.Current.Server.MapPath("~/IdPhoto");
        var provider = new MultipartFormDataStreamProvider(root);
        try
        {
            // Read the form data.
            await Request.Content.ReadAsMultipartAsync(provider);
            User user = new User(provider.FormData);
            System.Web.Security.MembershipCreateStatus status = MembershipCreateStatus.UserRejected;
            CVAppMembershipProvider mProvider = (CVAppMembershipProvider)System.Web.Security.Membership.Providers["CVAppMembershipProvider"];
            MembershipUser usr = mProvider.CreateUser(user, out status);
            if (status == MembershipCreateStatus.Success)
            {
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,
                  usr.UserName,
                  DateTime.Now,
                  DateTime.Now.AddMonths(1),
                  false,
                  "", //userData
                  FormsAuthentication.FormsCookiePath);
                ////Encrypt the ticket.
                string encTicket = FormsAuthentication.Encrypt(ticket);
                var resp = new HttpResponseMessage();
                //create and set cookie in response
                var cookie = new CookieHeaderValue(FormsAuthentication.FormsCookieName, encTicket);
                cookie.Expires = DateTimeOffset.Now.AddMonths(1);
                cookie.Domain = Request.RequestUri.Host;
                cookie.Path = "/";
                resp.Headers.AddCookies(new CookieHeaderValue[] { cookie });
            }
            else
            {
                throw new Exception(status.ToString() + " - " + GetErrorMessage(status));
            }
            // This illustrates how to get the file names.
            foreach (MultipartFileData file in provider.FileData)
            {
                string fileName = file.Headers.ContentDisposition.FileName;
                if (fileName.StartsWith("\"") && fileName.EndsWith("\""))
                {
                    fileName = fileName.Trim('"');
                }
                if (fileName.Contains(@"/") || fileName.Contains(@"\"))
                {
                    fileName = Path.GetFileName(fileName);
                }
                fileName = user.UserName.Replace(" ", "_") + "." + fileName.Substring(fileName.IndexOf(".") + 1);
                File.Copy(file.LocalFileName, Path.Combine(root, fileName));
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }
        catch (Exception e)
        {
            //return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            throw e;
        }
    }
