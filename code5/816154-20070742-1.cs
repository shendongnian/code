    public class ImageButton : Button {
        public static readonly DependencyProperty imageOffProperty = DependencyProperty.Register("imageOff", typeof(Image), typeof(ImageButton), new PropertyMetadata(null));
        public Image imageOff {
            get { return (Image)GetValue(imageOffProperty); }
            set { SetValue(imageOffProperty, value); }
        }
        public static readonly DependencyProperty imageOnProperty = DependencyProperty.Register("imageOn", typeof(Image), typeof(ImageButton), new PropertyMetadata(null));
        public Image imageOn {
            get { return (Image)GetValue(imageOnProperty); }
            set { SetValue(imageOnProperty, value); }
        }
        static ImageButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ImageButton), new FrameworkPropertyMetadata(typeof(ImageButton)));
        }
    }
