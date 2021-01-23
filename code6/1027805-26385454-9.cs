	while (!streamReader.EndOfStream)
	{
		var line = streamReader.ReadLine();
		process.StandardInput.WriteLine(line);
		Console.WriteLine(line);
		process.BeginOutputReadLine();
		process.BeginErrorReadLine();
		autoResetEvent.WaitOne();
	}
