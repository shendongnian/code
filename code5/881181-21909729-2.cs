    [LayoutRenderer("event-context-dateTime")]
    public class DateTimeContextLayoutRenderer : EventContextLayoutRenderer
    {
        protected override void Append(StringBuilder builder, LogEventInfo logEvent)
        {
            object value;
            if (logEvent.Properties.TryGetValue(this.Item, out value))
            {
                //Your code here
            }
        }
    }
