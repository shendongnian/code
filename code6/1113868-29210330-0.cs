    // log4net.Appender.TraceAppender
    protected override void Append(LoggingEvent loggingEvent)
    {
    	Trace.Write(base.RenderLoggingEvent(loggingEvent), this.m_category.Format(loggingEvent));
    	if (this.m_immediateFlush)
    	{
    		Trace.Flush();
    	}
    }
