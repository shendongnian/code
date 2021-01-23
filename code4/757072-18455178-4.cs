	public static void readFileAsync(FileReader filereader)
	{
		var readf = new ReadFile(filereader.ReadLine);
		Action<IAsyncResult> callBack = null;
		callBack = iar =>
		{
			var line = readf.EndInvoke(iar);
			writefile.writeLine(line);
			if (!filereader.IsFinished)
			{
				readf.BeginInvoke(new AsyncCallback(callBack), null);
			}
		};
		if (!filereader.IsFinished)
		{
			readf.BeginInvoke(new AsyncCallback(callBack), null);
		}
	}
