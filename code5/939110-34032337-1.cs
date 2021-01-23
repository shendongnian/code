    public class LogDatabaseSaverAppender : AppenderSkeleton
    {
        [Dependency]
        public IContextCreator ContextCreator { get; set; }
    
        ...
    }
