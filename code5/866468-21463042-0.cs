                SmallImage =  prj.SmallImage == null 
                            ? null 
                            : new Image 
                 {
                     Extension = prj.SmallImage.Extension, //prj.smallimage is an entity in my datalayer
                     FileContent = new ImageContent
                       {
                           Id = prj.SmallImage.FileContent.Id, 
                           Content = prj.SmallImage.FileContent.Content
                       }, 
                     Filename = prj.SmallImage.Filename, 
                     Height = prj.SmallImage.Height, 
                     Id = prj.SmallImage.Id, 
                     IsDeleted = prj.SmallImage.IsDeleted, 
                     IsPublished = prj.SmallImage.IsPublished, 
                     LastModified = prj.SmallImage.LastModified, 
                     MimeType = prj.SmallImage.MimeType, 
                     PublishEnd = prj.SmallImage.PublishEnd,
                     PublishStart = prj.SmallImage.PublishStart
                 }
