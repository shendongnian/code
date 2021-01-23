    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    namespace ImageControl
    {
        public class ImageDialogue : Control
        {
            public ImageDialogue()
            {
                //applies the default style for the control (see ControlTemplate below)
                DefaultStyleKey = typeof (ImageDialogue);
            }
            public static readonly DependencyProperty ImageSourceProperty =
                DependencyProperty.Register("ImageSource", typeof (ImageSource), typeof (ImageDialogue), new PropertyMetadata(default(ImageSource)));
            public ImageSource ImageSource
            {
                get { return (ImageSource) GetValue(ImageSourceProperty); }
                set { SetValue(ImageSourceProperty, value); }
            }
        }
    }
