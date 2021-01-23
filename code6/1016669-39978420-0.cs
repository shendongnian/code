    public class NewRelicExceptionLogger : ExceptionLogger
    {
        public override void Log(ExceptionLoggerContext context)
        {
            NewRelic.Api.Agent.NewRelic.NoticeError(context.ExceptionContext.Exception);
        }
    }
