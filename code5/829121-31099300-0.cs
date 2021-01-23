public class HostingMiddleware : OwinMiddleware
{
    private readonly ILogger _logger;
    public HostingMiddleware(OwinMiddleware next, IAppBuilder builder)
        : base(next)
    {
        _logger = builder.CreateLogger<HostingMiddleware>();
    }
    public async override Task Invoke(IOwinContext context)
    {
        _logger.WriteVerbose(string.Format("{0} --- {1}", context.Request.Uri.AbsolutePath, context.Request.QueryString);
        await Next.Invoke(context);
    }
}
