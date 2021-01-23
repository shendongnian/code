            var fileInfo = new FileInfo(folderPath);
            var folderProperties = fileInfo.GetType().GetProperties();
            foreach (var property in folderProperties)
            {
                    var propName = property.Name
                    var propValue = property.GetValue(fileInfo, null);
                    //do stuff                                         
            }
