	foreach (FileSystemAccessRule rule in rules)
	{
		if (rule.IdentityReference.Value == listView1.SelectedItems[0].Text)
		{
			RemoveFileSecurity(path, rule);
			MessageBox.Show("OK");
		}
	}
	public static void RemoveFileSecurity(string fileName, FileSystemAccessRule rule)
	{
		// Get a FileSecurity object that represents the 
		// current security settings.
		FileSecurity fSecurity = File.GetAccessControl(fileName);
		
		// Remove the FileSystemAccessRule from the security settings.
		fSecurity.RemoveAccessRule(rule);
		// Set the new access settings.
		File.SetAccessControl(fileName, fSecurity);
	}
