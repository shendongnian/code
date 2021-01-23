    public static void UploadFile(List list,string filePath,IDictionary<string,object> itemProperties)
    {
            var ctx = list.Context;
            var fileInfo = new FileCreationInformation();
            fileInfo.Url = Path.GetFileName(filePath);
            fileInfo.Overwrite = true;
            fileInfo.Content = System.IO.File.ReadAllBytes(filePath);
            var file = list.RootFolder.Files.Add(fileInfo);
            var listItem = file.ListItemAllFields;
            foreach (var p in itemProperties)
            {
                listItem[p.Key] = p.Value;
            }    
            listItem.Update();
            ctx.ExecuteQuery();
    }
