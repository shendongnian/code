    public class TextBoxAppender : AppenderSkeleton
    {
        ...(constructor and other stuff omitted)...
        protected override void Append(log4net.Core.LoggingEvent loggingEvent)
        {
            // format your message in the layout, not here
            // var msg = string.Concat(loggingEvent.RenderedMessage, "\r\n");
    		_textBox.AppendText(base.RenderLoggingEvent(loggingEvent));
        }
    }
