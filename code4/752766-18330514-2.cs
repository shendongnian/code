    	// This is the function I currently have that only returns 1 folder
		// needs to somehow be expanded to return devices for all folders beneath it too
		function GetFolderDevices(int folderId, PaginationOptions options)
		{
				// Get all folders and devices
				using (var dbObj = this.context.CreateDBContext())
				{
						EMDB.Models.Folder folder = dbObj
								.AddressBook
								.Include(a => a.Devices.Select(d => d.Settings))
								.FirstOrDefault(f => f.FolderId == folderId);
						var result = from fold in Descendants(folder)
									 select fold;
						// apply pagination here (already taken care of)
				}
		}
