    class TextboxTraceListener : TraceListener
    {
	private DebugRichTextbox output;
	private Color debugColor;
	private Color traceColor;
	public TextboxTraceListener(DebugRichTextbox output) :this(output, "RichTextboxTraceListener", Color.Black, Color.Black)
	{
	}
	public TextboxTraceListener(DebugRichTextbox output, string name, Color debugColor, Color traceColor)
	{
		this.Name = name;
		this.output = output;
		this.debugColor = debugColor;
		this.traceColor = traceColor;
	}
	public override void Write(string message)
	{
		Color thisColor = Color.Black;
		StackTrace trace = new StackTrace();
		StackFrame[] stackFrames = trace.GetFrames();
		if (Array.Exists(stackFrames, element => element.GetMethod().DeclaringType.Name.ToUpper().Equals("TRACE")))
		{
			thisColor = traceColor;
		}
		if (Array.Exists(stackFrames, element => element.GetMethod().DeclaringType.Name.ToUpper().Equals("DEBUG")))
		{
			thisColor = debugColor;
		}
		Action write = delegate() { output.write(message, thisColor); };
		if (output.InvokeRequired)
		{
			IAsyncResult result = output.BeginInvoke(write);
			output.EndInvoke(result);
		}
		else
		{
			write();
		}
	}
	public override void WriteLine(string message)
	{
		Color thisColor = Color.Black;
		StackTrace trace = new StackTrace();
		StackFrame[] stackFrames = trace.GetFrames();
		if (Array.Exists(stackFrames, element => element.GetMethod().DeclaringType.Name.ToUpper().Equals("TRACE")))
		{
			thisColor = traceColor;
		}
		if (Array.Exists(stackFrames, element => element.GetMethod().DeclaringType.Name.ToUpper().Equals("DEBUG")))
		{
			thisColor = debugColor;
		}
		Action writeLine = delegate() { output.writeLine(message, thisColor); };
		if (output.InvokeRequired)
		{
			IAsyncResult result = output.BeginInvoke(writeLine);
			output.EndInvoke(result);
		}
		else
		{
			writeLine();
		}
	}
    }
