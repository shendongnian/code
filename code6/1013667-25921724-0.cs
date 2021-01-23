    using Xamarin.Media;
    // ...
    
    var picker = new MediaPicker ();
    if (!picker.IsCameraAvailable)
        Console.WriteLine ("No camera!");
    else {
        try {
            MediaFile file = await picker.TakePhotoAsync (new StoreCameraMediaOptions {
                Name = "test.jpg",
                Directory = "MediaPickerSample"
            });
    
            Console.WriteLine (file.Path);
        } catch (OperationCanceledException) {
            Console.WriteLine ("Canceled");
        }
    }
