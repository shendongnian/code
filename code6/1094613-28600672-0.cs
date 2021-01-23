		public void Add(string fileName, string entryName, int attributes) {
			if (fileName == null) {
				throw new ArgumentNullException("fileName");
			}
			if (entryName == null) {
				throw new ArgumentNullException("entryName");
			}
			CheckUpdating();
			ZipEntry entry = EntryFactory.MakeFileEntry(entryName);
			entry.ExternalFileAttributes = attributes;
			AddUpdate(new ZipUpdate(fileName, entry));
		}
