     Uri uri = new Uri("http://localhost:50222/odata");
             var container = new CourseServiceRef.Container(uri);
             CourseServiceRef.NotNeeded newTempAccount = new CourseServiceRef.NotNeeded()
                { 
                   Email = model.UserName,
                   Username1 = model.UserName 
                };
    
             if (newTempAccount != null)
            {
                container.AddToNotNeededs(newTempAccount);
                container.SaveChanges();
            }           
