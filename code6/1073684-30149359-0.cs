        MediaCapture mediacapture = new MediaCapture();
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (initialized == false)
            {
                var cameraID = await GetCameraID(Windows.Devices.Enumeration.Panel.Back);
                await mediacapture.InitializeAsync(new MediaCaptureInitializationSettings
                {
                    StreamingCaptureMode = StreamingCaptureMode.Video,
                    PhotoCaptureSource = PhotoCaptureSource.Photo,
                    AudioDeviceId = string.Empty,
                    VideoDeviceId = cameraID.Id
                });
            }
            //Selecting Maximum resolution for Video Preview
            var maxPreviewResolution = mediacapture.VideoDeviceController.GetAvailableMediaStreamProperties(MediaStreamType.VideoPreview).Aggregate((i1, i2) => (i1 as VideoEncodingProperties).Height > (i2 as VideoEncodingProperties).Height ? i1 : i2);
            //Selecting 4rd resolution setting
            var selectedPhotoResolution = mediacapture.VideoDeviceController.GetAvailableMediaStreamProperties(MediaStreamType.Photo).ElementAt(3);
            await mediacapture.VideoDeviceController.SetMediaStreamPropertiesAsync(MediaStreamType.Photo, selectedPhotoResolution);
            await mediacapture.VideoDeviceController.SetMediaStreamPropertiesAsync(MediaStreamType.VideoPreview, maxPreviewResolution);
            // in my .xaml <CaptureElement Name="viewfinder" />
            viewfinder.Source = mediacapture;
            mediacapture.SetPreviewRotation(VideoRotation.Clockwise90Degrees);
            await mediacapture.StartPreviewAsync(); 
        }
