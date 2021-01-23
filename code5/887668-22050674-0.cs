	DateTime today = DateTime.Today;
	foreach (string filename in Directory.GetFiles("C:\\Users\\username\\Desktop\\123")) {
		DateTime fileModDate = File.GetLastWriteTime(filename);
		if (fileModDate < today.AddDays(-2)) {
			File.Copy(filename, destination);
		}
	}
