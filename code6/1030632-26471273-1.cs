	if (ofd.ShowDialog() == DialogResult.OK)
	{
		filename_noext = System.IO.Path.GetFileName(ofd.FileName);
		path = Path.GetFullPath(ofd.FileName);
		img_path.Text = filename_noext;
		// MessageBox.Show(filename_noext, "Filename");
		// MessageBox.Show(full_path, "path");
		// move file from location to debug
		string replacepath = @"E:\Debug";
		string fileName = System.IO.Path.GetFileName(path);
		string newpath = System.IO.Path.Combine(replacepath, fileName);
		if (!System.IO.File.Exists(filename_noext))
			System.IO.File.Copy(path, newpath);
	}
	else
	{
		return String.Empty;
	}
