    class Camera
        {
            BitmapImage CurrentFrame { get; set; }
            BitmapImage CapturedFrame { get; set; }
            VideoCaptureDevice CaptureDevice { get; set; }
    
            void TakePhoto();
            void ClearFrame();
            void Reset();
        }
