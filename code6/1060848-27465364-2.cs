	using System.Runtime.InteropServices;
	using System.Diagnostics;
	using System.IO;
	using System.Xml;
	...
	
	[DllImport("shell32.dll")]
	private static extern Int32 SHGetKnownFolderPath([MarshalAs(UnmanagedType.LPStruct)] Guid rfid, UInt32 dwFlags, IntPtr hToken, ref IntPtr ppszPath);
	public void GetLibraryFolders()
	{
		IntPtr dirPtr = default(IntPtr);
		string LibDir = null;
		List<string> dirList = new List<string> { };
		SHGetKnownFolderPath(new Guid("491E922F-5643-4AF4-A7EB-4E7A138D8174"), 0, IntPtr.Zero, ref dirPtr);
		LibDir = System.Runtime.InteropServices.Marshal.PtrToStringUni(dirPtr);
		System.Runtime.InteropServices.Marshal.FreeCoTaskMem(dirPtr);
		using (XmlReader reader = XmlReader.Create(LibDir)) {
			while (reader.ReadToFollowing("simpleLocation")) {
				reader.ReadToFollowing("url");
				dirList.Add(reader.ReadElementContentAsString());
			}
		}
		for(int i = 0; i < dirList.Count; i++){
			if (dirList[i].Contains("knownfolder")) {
					dirList[i] = dirList[i].Replace("knownfolder:{", "");
					dirList[i] = dirList[i].Replace("}", "");
					SHGetKnownFolderPath(new Guid(dirList[i]), 0, IntPtr.Zero, ref dirPtr);
					dirList[i] = System.Runtime.InteropServices.Marshal.PtrToStringUni(dirPtr);
					System.Runtime.InteropServices.Marshal.FreeCoTaskMem(dirPtr);
			}
		}
	}
