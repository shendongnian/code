    // First get the list of all your pictures in the pictures library
    var allMyPictures = await KnownFolders.PicturesLibrary.GetFilesAsync();
    // iterate trough your pictures
    foreach (var file in allMyPictures)
    {
        // Get all the properties
        var properties = await file.Properties.GetImagePropertiesAsync();
        // Get the orientation
        var orientation = properties.Orientation;
    }
