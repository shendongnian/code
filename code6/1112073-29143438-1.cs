    foreach (var groupedFiles in files.GroupBy(s => s.Split('\\')[0]))
    {
         if (Path.GetExtension(groupedFiles.Key) == string.Empty)
         {
              //this is a folder
              var folder = groupedFiles.Key;
              var folderFiles = groupedFiles.ToList();
         }
         else
         {
              //this is a file
              var file = groupedFiles.First();
         }
    }
