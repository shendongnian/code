     public class CustomLogFileAppender : SitecoreLogFileAppender
        {
            protected override void Append(LoggingEvent loggingEvent)
            {
                if (Sitecore.Context.Site != null )
                {
    
                    if(loggingEvent.Level == Level.FATAL)
                    {
                        AppsInsightsLogHelper.Critical(loggingEvent.RenderedMessage);
                    }
    
                    if (loggingEvent.Level == Level.ERROR)
                    {
                        AppsInsightsLogHelper.Error(loggingEvent.RenderedMessage);
                    }
    
                    if (loggingEvent.Level == Level.WARN)
                    {
                        AppsInsightsLogHelper.Warning(loggingEvent.RenderedMessage);
                    }
    
                    if(loggingEvent.Level == Level.INFO)
                    {
                        AppsInsightsLogHelper.Info(loggingEvent.RenderedMessage);
                    }
    
    
                }
    
                    base.Append(loggingEvent);
            }
        }
