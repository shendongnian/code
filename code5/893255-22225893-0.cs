    [HttpPost]
    public ActionResult Return(DeviceUsage dev)
    {
        ValidateRequestHeader(Request);
        //process action
    }
    void ValidateRequestHeader(HttpRequestBase request)
    {
        string cookieToken = "";
        string formToken = "";
        if (request.Headers["RequestVerificationToken"] != null)
        {
            string[] tokens = request.Headers["RequestVerificationToken"].Split(':');
            if (tokens.Length == 2)
            {
                cookieToken = tokens[0].Trim();
                formToken = tokens[1].Trim();
            }
        }
        AntiForgery.Validate(cookieToken, formToken);
    }
