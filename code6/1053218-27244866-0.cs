    StorageFolder folder = ApplicationData.Current.LocalFolder;
    StorageFolder contactImagesfolder = await folder.CreateFolderAsync("ContactImages", CreationCollisionOption.OpenIfExists);
    StorageFile picture = await contactImagesfolder.CreateFileAsync(imageURL.Split('/').Last(), CreationCollisionOption.FailIfExists);
    HttpClient httpClient = new HttpClient();
    // Increase the max buffer size for the response so we don't get an exception with so many web sites
    httpClient.MaxResponseContentBufferSize = 256000;
    HttpResponseMessage response = await httpClient.GetAsync(imageURL);
    var responseByteArray = await response.Content.ReadAsByteArrayAsync();
    await FileIO.WriteBytesAsync(picture, responseByteArray);
    Dal.Instance.UpdateContactImage(contactID, imageURL);
