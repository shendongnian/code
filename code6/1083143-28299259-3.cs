            imagePicker.FinishedPickingMedia += (sender, e) => {
                var filepath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "tmp.png");
                var image = (UIImage)e.Info.ObjectForKey(new NSString("UIImagePickerControllerOriginalImage"));
                InvokeOnMainThread(() => {
                    image.AsPNG().Save(filepath, false);
                    App.Instance.ShowImage(filepath);
                });
                DismissViewController(true, null);
            };
