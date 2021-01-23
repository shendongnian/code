    IEnumerable<Windows.ApplicationModel.Package> apps = Windows.Phone.Management.Deployment.InstallationManager.FindPackages();
    foreach(var app in apps)
    {
      if(app.Id.ProductId.Equals("APP_ID", StringComparison.InvariantCultureIgnoreCase)
      {
         var token = p.GetThumbnailToken();
         var name = app.Id.Name + SharedStorageAccessManager.GetSharedFileName(token);
         await SharedStorageAccessManager.CopySharedFileAsync(ApplicationData.Current.LocalFolder, name, NameCollisionOption.ReplaceExisting, token);
         var file = await ApplicationData.Current.LocalFolder.GetFileAsync(name);                    
         var randomStream = await file.OpenReadAsync();
         Stream stream = randomStream.AsStream();
      }
    }
