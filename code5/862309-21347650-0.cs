    static void Main(string[] args)
    {
        TextWriterTraceListener textListener = new TextWriterTraceListener("myListener.log");
        // New code starts here
        var sourceSwitch =  new SourceSwitch("SourceSwitch", "Verbose");
        mySource.Switch = sourceSwitch;
        // New code ends here
        mySource.Listeners.Add(textListener);
        // ...
