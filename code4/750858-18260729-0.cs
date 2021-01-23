	string input = Path.GetFileName(originalFile);
	     //"S012311d130614t095121.14194092001";
	string yearMonthDay = input.Substring(8, 6);
	
	string yearMonth = yearMonthDay.Substring(0, 4);
	Console.WriteLine(yearMonth);
	
	string folder = Path.Combine(Path.Combine(rootFolder, yearMonth), yearMonthDay);
	Directory.CreateDirectory(folder);
	
	// Write to folder
    File.Copy(originalFile, Path.Combine(folder, input);
