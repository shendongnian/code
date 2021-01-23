    public namespace MyApp
    {
        public class ErrorFlagAppender : AppenderSkeleton
        {
            public bool ErrorOccurred { get; set; }
	
            protected override void Append(LoggingEvent loggingEvent)
            {
                ErrorOccurred = true;
            }
        }
    } 
