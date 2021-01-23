    public class StringWriterNoEncoding : StringWriter
    {
    	public override Encoding Encoding
    	{
    		get { return null; }
    	}
    }
