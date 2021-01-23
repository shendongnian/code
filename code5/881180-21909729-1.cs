    public class EventContextLayoutRenderer : LayoutRenderer
    {
        //....
        protected override void Append(StringBuilder builder, LogEventInfo logEvent)
        {
            object value;
            if (logEvent.Properties.TryGetValue(this.Item, out value))
            {
                builder.Append(Convert.ToString(value, CultureInfo.InvariantCulture));
            }
        }
    }
