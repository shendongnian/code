    public class ScheduledAppender : FileAppender
    {
        protected override void Append(LoggingEvent loggingEvent)
        {
           if (SchedulingLogic.ItIsTimeToLog) // Your scheduling logic here
           {
               base.Append(loggingEvent);
           }
        }
    } 
