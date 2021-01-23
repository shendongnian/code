	var dummy = new Dummy();
	dummy.FileChangedHandler += ConfigFileChanged;
	dummy.UseTheAction(ConfigFileChanged);
	
	private void ConfigFileChanged(object source, FileSystemEventArgs e)
	{
		Console.WriteLine("Event fired");
	}
