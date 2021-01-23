        [HandleError(ExceptionType=typeof(NullReferenceException), View="Error")]
        public string Home(string name)
        {
            ...
        }
        protected override void OnException(ExceptionContext filterContext)
        {
            if (filterContext.ExceptionHandled)
            {
                return;
            }
            // do something
            base.OnException(filterContext);
        }
