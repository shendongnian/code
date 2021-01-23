    public sealed partial class LocalImage : UserControl
    {
        public static readonly DependencyProperty SourceProperty = DependencyProperty.Register("Source", typeof (string),
            typeof (LocalImage), new PropertyMetadata(null, SourceChanged));
        public LocalImage()
        {
            this.InitializeComponent();
        }
        public string Source
        {
            get { return this.GetValue(SourceProperty) as string; }
            set { this.SetValue(SourceProperty, value); }
        }
        private async static void SourceChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            var control = (LocalImage)obj;
            var path = e.NewValue as string;
            if (string.IsNullOrEmpty(path))
            {
                control.Image.Source = null;
            }
            else
            {
                var file = await StorageFile.GetFileFromPathAsync(path);
                using (var fileStream = await file.OpenAsync(FileAccessMode.Read))
                {
                    BitmapImage bitmapImage = new BitmapImage();
                    await bitmapImage.SetSourceAsync(fileStream);
                    control.Image.Source = bitmapImage;
                }
            }
        }
    }
