    /// <summary>
    /// This utility class provides an attached property that enables us to
    /// bind the source of a <see cref="CaptureElement"/>.
    /// </summary>
    public static class VideoSourceBinding {
        public static MediaCapture GetVideoSource(DependencyObject obj) {
            return (MediaCapture) obj.GetValue(VideoSourceProperty);
        }
        public static void SetVideoSource(DependencyObject obj,
                MediaCapture value) {
            obj.SetValue(VideoSourceProperty, value);
        }
        public static readonly DependencyProperty VideoSourceProperty
            = DependencyProperty.RegisterAttached("VideoSource",
            typeof(MediaCapture),
            typeof(VideoSourceBinding),
            new PropertyMetadata(null, onVideoSourcePropertyChanged));
        private static async void onVideoSourcePropertyChanged(
                DependencyObject d, DependencyPropertyChangedEventArgs e) {
            Debug.Assert(d is CaptureElement);
            Debug.Assert(e.Property == VideoSourceBinding.VideoSourceProperty);
            CaptureElement preview = d as CaptureElement;
            if (d != null) {
                if (preview.Source != null) {
                    // If another camera was attached before, stop it.
                    await preview.Source.StopPreviewAsync();
                }
                try {
                    preview.Source = (MediaCapture) e.NewValue;
                } catch {
                    // The property change occurred before the the video source
                    // was properly initialised. In this case, we ignore the
                    // change and wait for the source to fire the event again
                    // once the initialisation was completed.
                    // Important: The source must actually change in order for
                    // the event to be fired (the attached property will detect
                    // if the same object was re-set) and ignore this.
                    preview.Source = null;
                }
                if (preview.Source != null) {
                    // Start the preview stream.
                    await preview.Source.StartPreviewAsync();
                }
            }
        }
    }
