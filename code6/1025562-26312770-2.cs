    using System;
    using System.IO;
    using Windows.Storage;
    using Windows.Storage.Pickers;
  
    // ...
    var picker = new FileOpenPicker();
    picker.FileTypeFilter.Add(".jpg");
    var file = await picker.PickSingleFileAsync();
    using (var randomAccessStream = await file.OpenAsync(FileAccessMode.Read))
    {
        using (var stream = randomAccessStream.AsStream())
        {
            using (var reader = new ExifReader(stream))
            {
                string model;
                if (reader.GetTagValue(ExifTags.Model, out model))
                {
                    var dialog = new MessageDialog(model, "Camera Model");
                    dialog.ShowAsync();
                }
            }
        }
    }
