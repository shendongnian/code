    [LayoutRenderer("stacktrace")]
    public class CustomStackTraseLayoutRenderer : StackTraceLayoutRenderer
    {
       [DefaultValue(0)]
       public int SkipFrames { get; set; } // configurable
       protected override void Append(StringBuilder builder, LogEventInfo logEvent)
       {
           int startingFrame = logEvent.UserStackFrameNumber + TopFrames - 1;
           if (startingFrame >= logEvent.StackTrace.FrameCount)
               startingFrame = logEvent.StackTrace.FrameCount - 1;
            bool first = true;
            int endingFrame = logEvent.UserStackFrameNumber + SkipFrames;
            for (int i = startingFrame; i >= endingFrame; --i)
            {
                StackFrame f = logEvent.StackTrace.GetFrame(i);
                switch (Format)
                {
                    case StackTraceFormat.Raw:
                        builder.Append(f.ToString());
                        break;
                    case StackTraceFormat.Flat:
                        if (!first)
                            builder.Append(this.Separator);
                        var type = f.GetMethod().DeclaringType;
                        builder.Append(type == null ? "<no type>" : type.Name);
                        builder.Append(".");
                        builder.Append(f.GetMethod().Name);
                        first = false;
                        break;
                    case StackTraceFormat.DetailedFlat:
                        if (!first)
                            builder.Append(this.Separator);
                        builder.Append("[" + f.GetMethod() + "]");
                        first = false;
                        break;
                }
            }
        }
    }
