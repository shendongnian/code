	var path = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDocuments);
	var filename = System.IO.Path.Combine(path.ToString(), strFile);
	System.IO.FileStream fs = new FileStream(filename, FileMode.Open);
	byData = new byte[fs.Length];
	fs.Read(byData, 0, (int)fs.Length);
	fs.Close();
