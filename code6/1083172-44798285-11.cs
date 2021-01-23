    if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
    {
        await DisplayAlert("No Camera", ":( No camera avaialble.", "OK");
        return;
    }
    var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
    {
        PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium,
        Directory = "Sample",
        Name = "test.jpg"
    });
    if (file == null)
        return;
    await DisplayAlert("File Location", file.Path, "OK"); 
