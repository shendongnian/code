    public class ViewModel : Screen {
        // Note: The sample uses a Caliburn Micro base class - this is, however, not
        // a requirement.
        public MediaCapture VideoCapture {
            get;
            private set;
        }
        /// <summary>
        /// Starts the video preview.
        /// </summary>
        /// <remarks>
        /// Call this method whenever it is necessary to (re-) start the preview, eg
        /// if the page is activated or if the settings have changed.
        /// </remarks>
        private async void startVideo() {
            var captureSettings = new MediaCaptureInitializationSettings() {
                StreamingCaptureMode = StreamingCaptureMode.Video
            };
            // Set a NEW MediaCapture! Do not re-use the old one, because the property 
            // change event of the attached property will not fire otherwise.
            this.VideoCapture = new MediaCapture();
            await this.videoCapture.InitializeAsync(captureSettings);
            // Notify the UI about a new video source AFTER the initialisation completed. It 
            // is important to await the initialisation here.
            this.NotifyOfPropertyChange(() => this.VideoCapture);
        }
    }
