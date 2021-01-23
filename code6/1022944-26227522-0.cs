      public override void OnException(ExceptionContext filterContext)
      {
          if (filterContext.Exception != null)
          {
            // do something
          }
          base.OnException(filterContext);
      }
