	var extensions = new Stack<string>(); // if you use a list you'll have to reverse it later for FIFO rather than LIFO
	string filenameExtension;
	while( !string.IsNullOrWhiteSpace(filenameExtension = Path.GetExtension(inputPath)) )
	{
		// remember latest extension
		extensions.Push(filenameExtension);
		// remove that extension from consideration
		inputPath = inputPath.Substring(0, inputPath.Length - filenameExtension.Length);
	}
	filenameExtension = string.Concat(extensions); // already has preceding periods
