    public static readonly DependencyProperty VersionNumberProperty = DependencyProperty.Register(
            "VersionNumber", typeof (string), typeof (UserControl1), new PropertyMetadata(default(string)));
        public string VersionNumber
        {
            get { return (string) GetValue(VersionNumberProperty); }
            set { SetValue(VersionNumberProperty, value); }
        }
    public static readonly DependencyProperty BackgroundImageProperty = DependencyProperty.Register(
            "BackgroundImage", typeof (ImageSource), typeof (UserControl1), new PropertyMetadata(default(ImageSource)));
        public ImageSource BackgroundImage
        {
            get { return (ImageSource) GetValue(BackgroundImageProperty); }
            set { SetValue(BackgroundImageProperty, value); }
        }
