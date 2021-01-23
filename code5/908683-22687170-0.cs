    public override void OnActionExecuting(ActionExecutingContext filterContext)
    {
      var request = filterContext.HttpContext.Request;
      var id = WebSecurity.CurrentUserId;
      BackgroundTaskManager.Run(() =>
      {
        try
        {
          var audit = new Audit
          {
            Id = Guid.NewGuid(),
            IPAddress = request.UserHostAddress,
            UserId = id,
            Resource = request.RawUrl,
            Timestamp = DateTime.UtcNow
          };
          var database = (new NinjectBinder()).Kernel.Get<IDatabaseWorker>();
          database.Audits.InsertOrUpdate(audit);
          database.Save();
        }
        catch (Exception e)
        {
          var username = WebSecurity.CurrentUserName;
          Debugging.DispatchExceptionEmail(e, username);
        }
      });
      base.OnActionExecuting(filterContext);
    }
