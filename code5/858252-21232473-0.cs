	public override void Render(HtmlTextWriter output)
	{
		// string builder is just an example of storage that custom TextWriter uses
		var builder = new StringBuilder();
		var myCustomWriter = new HtmlTextWriterExtension(builder);
		base.Render(myCustomWriter);
		myCustomWriter.Flush();
		// write content written from base class to original writer
		output.Write(builder.ToString()); 
	}
