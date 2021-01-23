	var autoResetEvent = new AutoResetEvent(false); // this mutex acts as our bouncer for the reading-part
    var process = new Process
    {
        // all your init stuff
    };
	process.StartInfo.UseShellExecute = false;
	process.StartInfo.RedirectStandardOutput = true;
	process.OutputDataReceived += (sender, args) => {
		// TODO you could read the content here with args.Data
		autoResetEvent.Set();
	};
    process.Start();
	using (var memoryStream = new MemoryStream())
	{
		using (var streamWriter = new StreamWriter(memoryStream))
		{
			var xmlSerializer = new XmlSerializer(data.GetType());
			var xmlwriter = XmlWriter.Create(streamWriter, xmlWriterSettings);
			xmlSerializer.Serialize(xmlwriter, data);
		}
		memoryStream.Position = 0;
		using (var streamReader = new StreamReader(memoryStream))
		{
			while (!streamReader.EndOfStream)
			{
				var line = streamReader.ReadLine();
				process.StandardInput.WriteLine(line);
				
				Console.WriteLine(line);
				
				process.BeginOutputReadLine();
				autoResetEvent.WaitOne();
			}
		}
	}
    // TODO closing the process.StandardInput, exiting process, ...
