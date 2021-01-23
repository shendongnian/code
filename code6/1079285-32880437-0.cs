    protected override void OnException(ExceptionContext filterContext)
        {
            var jsonData = new StreamReader(filterContext.Request.InputStream).ReadToEnd();
            var aspError = JsonConvert.DeserializeObject<RemoteError>(jsonData);
            var elmahError = aspError.ToElmahError();
            ErrorLog.GetDefault(HttpContext.Current).Log(elmahError);
            ErrorMailModule mail = new ErrorMailModule;
            mail.SendErrorMail(elmahError); 
            Elmah.ErrorSignal.FromCurrentContext().Raise(filterContext.Exception); // to store error
            base.OnException(filterContext);
        }
