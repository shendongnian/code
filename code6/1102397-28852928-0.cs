    public override void ExecuteResult(ControllerContext context)
        {
            if (context == null) throw new ArgumentNullException("context");
    
            // this is really the key to bringing up the basic authentication login prompt.
            // this header is what tells the client we need basic authentication
            var res = context.HttpContext.Response;
            res.StatusCode = 401;
            res.AddHeader("WWW-Authenticate", "Basic");
            res.End();
            base.ExecuteResult(context);
        }
