[assembly: Xamarin.Forms.Dependency(typeof(CameraProvider))]
    public class CameraProvider : ICameraProvider
    {
        private UIImagePickerController _imagePicker;
        private CameraResult _result;
        private static TaskCompletionSource<CameraResult> _tcs;
        public async Task<CameraResult> TakePhotoAsync()
        {
            _tcs = new TaskCompletionSource<CameraResult>();
            _imagePicker = new UIImagePickerController { SourceType = UIImagePickerControllerSourceType.Camera };
            _imagePicker.FinishedPickingMedia += (sender, e) =>
            {
                _result = new CameraResult();
                var filepath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "tmp.png");
                var image = (UIImage)e.Info.ObjectForKey(new NSString("UIImagePickerControllerOriginalImage"));
                _result.ImageSource = ImageSource.FromStream(() => new MemoryStream(image.AsPNG().ToArray())); 
                _result.ImageBytes = image.AsPNG().ToArray();
                _result.FilePath = filepath;
                _tcs.TrySetResult(_result);
                _imagePicker.DismissViewController(true, null);
            };
            _imagePicker.Canceled += (sender, e) =>
            {
                UIApplication.SharedApplication.KeyWindow.RootViewController.DismissViewController(true, null);
            };
            await UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewControllerAsync(_imagePicker, true);
            return await _tcs.Task; 
        }
        public async Task<CameraResult> PickPhotoAsync()
        {
            _tcs = new TaskCompletionSource<CameraResult>();
            _imagePicker = new UIImagePickerController
            {
                SourceType = UIImagePickerControllerSourceType.PhotoLibrary,
                MediaTypes = UIImagePickerController.AvailableMediaTypes(UIImagePickerControllerSourceType.PhotoLibrary)
            };
            _imagePicker.FinishedPickingMedia += (sender, e) =>
            {
                if (e.Info[UIImagePickerController.MediaType].ToString() == "public.image")
                {
                    var filepath = (e.Info[new NSString("UIImagePickerControllerReferenceUrl")] as NSUrl);
                    var image = (UIImage)e.Info.ObjectForKey(new NSString("UIImagePickerControllerOriginalImage"));
                    //var image = e.Info[UIImagePickerController.OriginalImage] as UIImage;
                    _result.ImageSource = ImageSource.FromStream(() => new MemoryStream(image.AsPNG().ToArray()));
                    _result.ImageBytes = image.AsPNG().ToArray();
                    _result.FilePath = filepath?.Path;
                }
                _tcs.TrySetResult(_result);
                _imagePicker.DismissViewController(true, null);
            };
            _imagePicker.Canceled += (sender, e) =>
            {
                UIApplication.SharedApplication.KeyWindow.RootViewController.DismissViewController(true, null);
            };
            await UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewControllerAsync(_imagePicker, true);
            return await _tcs.Task;
        }
    }
