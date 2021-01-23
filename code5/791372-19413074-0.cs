    private class AssertTextWriterTraceListener : TextWriterTraceListener
    {
        public AssertTextWriterTraceListener(TextWriter w) : base(w) {}
        public AssertTextWriterTraceListener(String s) : base(s) {}
        public override void Fail(string message)
        {
            // uncomment if you want the modal dialog
            //base.Fail(message);
            WriteLine(message);
        }
    }
