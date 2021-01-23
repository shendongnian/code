    public sealed class ObservableTraceListener : TraceListener
    {
        private readonly StringBuilder _Builder = new StringBuilder();
        
        static ObservableTraceListener()
        {
            PresentationTraceSources.Refresh();
        }
        public ObservableTraceListener()
        {
            PresentationTraceListener.Add(SourceLevels.Error, this);
        }
        public new void Dispose()
        {
            Flush();
            Close();
            PresentationTraceListener.Remove(this);
            base.Dispose();
        }   
        public override void Write(string message)
        {
            _Builder.Append(message);
        }
        public override void WriteLine(string message)
        {
            _Builder.Append(message);
            if (TraceCatched != null)
                TraceCatched(_Builder.ToString());
            _Builder.Clear();
        }
        public event Action<string> TraceCatched;
    }
