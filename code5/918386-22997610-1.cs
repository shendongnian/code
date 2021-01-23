    using System.Windows;
    using System.Windows.Media;
    
    namespace PhoneApp1
    {
        public partial class MyIconControl
        {
            public static readonly DependencyProperty ImageSourceProperty = DependencyProperty.Register(
                "ImageSource", typeof (ImageSource), typeof (MyIconControl),
                new PropertyMetadata(default(ImageSource), OnImageSourceChanged));
    
            public MyIconControl()
            {
                InitializeComponent();
            }
    
            public ImageSource ImageSource
            {
                get { return (ImageSource) GetValue(ImageSourceProperty); }
                set { SetValue(ImageSourceProperty, value); }
            }
    
            private static void OnImageSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                var control = (MyIconControl) d;
                var imageSource = e.NewValue as ImageSource;
                control.Image1.Source = imageSource;
            }
    
            private void RemoveImageClick(object sender, RoutedEventArgs e)
            {
                ImageSource = null;
            }
    
            private void ReplaceImageClick(object sender, RoutedEventArgs e)
            {
                /* Here for instance you could open the pictures folder
                 * let the user choose one and set the ImageSource with it
                 * like ImageSource = new BitmapImage(new Uri(yourimage.png)); */
            }
        }
    }
