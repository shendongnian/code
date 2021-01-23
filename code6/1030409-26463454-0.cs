    public interface IHaveManyFieldsToLog
    {
        public string[] GetAllPropertyValues()
    }
    
    public class ManyFieldsToLogAppender: SkeletonAppender
    {
        // pseudocode, I don't have the IDE at the moment
        public override AppendLog(LogEvent event)
        {
             if (event.Parameter[0] as IHaveManyFieldsToLog != null)
             {
                  var values = (event.Parameter[0] as IHaveManyFieldsToLog).GetAllPropertyValues();
                  // concat all values and push it to the log
             }
        }
    }
