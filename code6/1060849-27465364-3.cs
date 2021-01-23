     using System.Runtime.InteropServices;
     using System.Diagnostics;
     using System.IO;
     using System.Xml;
     
     
     [DllImport("shell32.dll")]
     private static extern int SHGetKnownFolderPath([MarshalAs(UnmanagedType.LPStruct)] Guid rfid, uint dwFlags, IntPtr hToken, ref IntPtr ppszPath);
     
     public void GetVideoLibraryFolders()
     {
         var pathPtr = default(IntPtr);
         var videoLibGuid = new Guid("491E922F-5643-4AF4-A7EB-4E7A138D8174");
         SHGetKnownFolderPath(videoLibGuid, 0, IntPtr.Zero, ref pathPtr);
     
         string path = Marshal.PtrToStringUni(pathPtr);
         Marshal.FreeCoTaskMem(pathPtr);
         List<string> foldersInLibrary = new List<string>();
     
         using (XmlReader reader = XmlReader.Create(path))
         {
             while (reader.ReadToFollowing("simpleLocation"))
             {
                 reader.ReadToFollowing("url");
                 foldersInLibrary.Add(reader.ReadElementContentAsString());
             }
         }
     
         for (int i = 0; i < foldersInLibrary.Count; i++)
         {
             if (foldersInLibrary[i].Contains("knownfolder"))
             {
                 foldersInLibrary[i] = foldersInLibrary[i].Replace("knownfolder:{", "");
                 foldersInLibrary[i] = foldersInLibrary[i].Replace("}", "");
     
                 SHGetKnownFolderPath(new Guid(foldersInLibrary[i]), 0, IntPtr.Zero, ref pathPtr);
                 foldersInLibrary[i] = Marshal.PtrToStringUni(pathPtr);
                 Marshal.FreeCoTaskMem(pathPtr);
             }
         }
    
        // foldersInLibrary now contains the path to all folders in the Videos Library
     }
