	List<string> lines = File.ReadAllLines("/file/path").ToList();
		
	// change line position
	String line = lines[3];
	lines.RemoveAt(3);
	lines.Insert(7, line);
	
	File.WriteAllLines("/file/path", lines.ToArray());
