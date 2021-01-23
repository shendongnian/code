	Restore restoreDB = new Restore();
	restoreDB.Database = settings.DestDBName;
	restoreDB.Action = RestoreActionType.Database;
	restoreDB.Devices.AddDevice(defaultBackupDir + backupFileRelativePath, DeviceType.File);
	restoreDB.ReplaceDatabase = true;
	restoreDB.NoRecovery = false;
	DataTable fileList = restoreDB.ReadFileList(destinationServer);
	foreach (DataRow row in fileList.Rows) {
		RelocateFile file = new RelocateFile();
		file.LogicalFileName = row[0].ToString();
		// Derive the physical location as the current physical location 
		string currentLocation = row[1].ToString();
		string extension = ".mdf";
		int extensionLoc = currentLocation.IndexOf(extension);
		if (extensionLoc <= 0) {
			extension = ".ldf";
			extensionLoc = currentLocation.IndexOf(extension);
		}
		if (extensionLoc <= 0) {
			extension = ".ndf";
			extensionLoc = currentLocation.IndexOf(extension);
		}
		if (extensionLoc <= 0) {
			continue;
		}
		string newLocation = currentLocation.Substring(0, extensionLoc);
		newLocation = newLocation + "_clone" + extension;
		file.PhysicalFileName = newLocation;
		restoreDB.RelocateFiles.Add(file);
	}
