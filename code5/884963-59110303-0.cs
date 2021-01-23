c#
[LayoutRenderer("aspnet-sessionid")]
[ThreadSafe]
public class AspNetSessionIdLayoutRenderer : AspNetLayoutRendererBase
{
    protected override void DoAppend(StringBuilder builder, LogEventInfo logEvent)
    {
        var context = HttpContextAccessor.HttpContext;
        var contextSession = context?.Session();
        if (contextSession == null)
        {
             InternalLogger.Debug("HttpContext Session Lookup returned null");
             return;
        }
        builder.Append(contextSession.SessionID); // ASP.NET Core: contextSession.Id
    }
}
