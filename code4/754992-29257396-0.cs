    private sealed class SourceVisitor : CefStringVisitor
    {
        private readonly Action<string> _callback;
        public SourceVisitor(Action<string> callback)
        {
            _callback = callback;
        }
        protected override void Visit(string value)
        {
            _callback(value);
        }
    }
    protected override void OnLoadEnd(CefBrowser browser, CefFrame frame, int httpStatusCode)
    {
            if (frame.IsMain)
            {
                string HtmlSourceCode;
                var visitor = new SourceVisitor(text =>
                {
                    BeginInvoke(new Action(() =>
                        {
                            HtmlSourceCode = text;
                        }));
                });
                frame.GetSource(visitor);
            }
    }
