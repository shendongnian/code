    string entry_name = TargetNamePrefix + ".csv"; // update this if needed
    using (ZipFile zip = ZipFile.Read(OutPutDirectoryPath))
    {
       // Set password for file
       zip.Password = zipFilePassword; 
       // Extract entry into a memory stream
       ZipEntry e = zip[entry_name];
       using(MemoryStream m = new MemoryStream())
       {
          e.Extract(m);
          // Update m stream
       }
       // Remove old entry
       zip.RemoveEntry(entry_name);
 
       // Add new entry
       zip.AddEntry(entry_name, m);
       // Save
       zip.Save(OutPutDirectoryPath);
    }
