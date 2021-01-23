    ...
    using System.IO.Compression; 
    ...
    
    
      public static int ZipFileCount(String zipFileName) {
        using (ZipArchive archive = ZipFile.Open(zipFileName, ZipArchiveMode.Read)) {
          int count = 0;
    
          // We count only named (i.e. that are with files) entries
          foreach (var entry in archive.Entries)
            if (!String.IsNullOrEmpty(entry.Name))
              count += 1;
    
          return count;
        }
      }
