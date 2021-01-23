    public static class LogManagerExtensions
    {
        public static bool AtLeastOneErrorHasBeenLogged(this LogManager logManager)
        {
            var flagAppenders = logManager.GetRepository()
                                          .GetAppenders()
                                          .OfType<ErrorFlagAppender>();
            return flagAppenders.Any(f => f. ErrorOccurred);
        }
    }
