    public class Writer : StreamWriter
    {
    	private readonly Assembly _assembly;
    
    	private readonly StreamWriter _stdout;
    
    	public Writer(Assembly assembly)
    		: base(Console.OpenStandardOutput())
    	{
    		_assembly = assembly;
    		_stdout = new StreamWriter(Console.OpenStandardOutput());
    	}
    
    	public override void Write(string value)
    	{
    		var st = new StackTrace();
    		var curent = st.GetFrames();
    		foreach (var frame in curent)
    		{
    			if (frame.GetMethod().Module.Assembly == _assembly)
    			{
    				_stdout.Write("Redirected: " + value);
    				_stdout.Flush();
    				return;
    			}
    		}
    
    		base.Write(value);
                this.Flush();
    	}
    }
