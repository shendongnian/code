    public class VisualStudioOutputWindowAppender : AppenderSkeleton
    {
        public IVisualStudioWriter OutputWindow { get; set; }
        public VisualStudioOutputWindowAppender(IVisualStudioWriter outputWindow)
        {
            OutputWindow = outputWindow;
            Layout = new PatternLayout("%-5level %logger - %message%newline");
        }
        protected override void Append(LoggingEvent loggingEvent)
        {
            if (null == OutputWindow)
                return;
            if (null == loggingEvent)
                return;
            OutputWindow.OutputString(RenderLoggingEvent(loggingEvent));
        }
    }
