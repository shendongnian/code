	// user entered 01.May
	String date = "2014-05-01 12:01:01"; // TextBox1.Text
	DateTime timestamp = DateTime.Now;
	// parse the entered string
	if (!DateTime.TryParse(date, out timestamp))
	{
		throw new FormatException("Entered Date/Time has an invalid format");
	}
	// take some files for the example
	var files = new DirectoryInfo("d:\\temp\\xml\\").GetFiles().ToList();
	// show all files
	files.ForEach(file => Console.WriteLine("{0} - {1}", file.CreationTime, file.Name));
	Console.WriteLine("Filtered");
	// filter files from May
	foreach (var file in files)
	{
		if (file.CreationTime >= timestamp)
		{
			Console.WriteLine("{0} - {1}", file.CreationTime, file.Name);
		}
	}
