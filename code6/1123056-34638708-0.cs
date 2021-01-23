    public static void LogError(Exception ex)
        {
            if (HttpContext.Current == null)
            {
                var errorlog = Elmah.ErrorLog.GetDefault(null);
                var error = new Elmah.Error();
                error.Message = ex.Message;
                error.Detail = ex.ToString();
                error.Time = DateTime.Now;
                error.Type = ex.GetType() + "[NoContext]";
                error.HostName = HostingEnvironment.SiteName;
                errorlog.Log(error);
            } else {
                Elmah.ErrorSignal.FromCurrentContext().Raise(ex);
            }
        }
