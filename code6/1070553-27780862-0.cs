        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
                if (actionExecutedContext.Response != null)
                {
                  //ok
                }
                else
                {
                    _logger.ErrorFormat("actionExecutedContext.Response == null will result in 500, unhandled exception"); //Add extra information here
                }
        }
