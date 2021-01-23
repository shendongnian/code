    public override void ExecuteResult(ControllerContext context)
    {
    if (context == null) throw new ArgumentNullException("context");
    context.HttpContext.Response.ContentType = "application/json";
    context.HttpContext.Response.ContentEncoding = System.Text.Encoding.UTF8;
    this.serializer.Serialize(context.HttpContext.Response.Output, this.Model);
    }
