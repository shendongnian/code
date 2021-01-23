    app.Use(async (ctx, next) =>
    {
      var endings = new[] { ".jpg", ".jpeg", ".png", ".gif" };
      if (endings.Any(e => ctx.Request.Path.Value.EndsWith(e)) &&
          ctx.Request.QueryString.HasValue &&
          File.Exists(HostingEnvironment.MapPath(ctx.Request.Path.Value)))
      {
        var inputStream = File.OpenRead(HostingEnvironment.MapPath(ctx.Request.Path.Value));
        var outputStream = ctx.Response.Body;
        var job = new ImageJob(inputStream, outputStream, new Instructions(ctx.Request.QueryString.Value));
        var cfg = new ImageResizer.Configuration.Config();
          cfg.Build(job);
      }
      else
      {
          await next();
      }
    });
