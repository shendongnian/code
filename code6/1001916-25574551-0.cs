    public class ImageData : DependencyObject
    {
        public static readonly DependencyProperty Base64ImageDataProperty =
            DependencyProperty.Register("Base64ImageData",
            typeof(string),
            typeof(ImageData));
        public string Base64ImageData
        {
            get { return (string)(GetValue(Base64ImageDataProperty)); }
            set { SetValue(Base64ImageDataProperty, value); }
        }
    }
