    public class ButtonWithImage :Button
    {
        public static readonly DependencyProperty DisableImageSourceProperty =
            DependencyProperty.Register("DisableImageSource", typeof (ImageSource), typeof (ButtonWithImage), new PropertyMetadata(default(ImageSource)));
        public ImageSource DisableImageSource
        {
            get { return (ImageSource) GetValue(DisableImageSourceProperty); }
            set { SetValue(DisableImageSourceProperty, value); }
        }
        public static readonly DependencyProperty EnableImageSourceProperty =
            DependencyProperty.Register("EnableImageSource", typeof (ImageSource), typeof (ButtonWithImage), new PropertyMetadata(default(ImageSource)));
        public ImageSource EnableImageSource
        {
            get { return (ImageSource) GetValue(EnableImageSourceProperty); }
            set { SetValue(EnableImageSourceProperty, value); }
        }
        public ButtonWithImage()
        {
            this.DefaultStyleKey = typeof (Button);
            
        }
    }
