      public class IconButton : Button
      {
           public static readonly DependencyProperty ImageSourceProperty =
            DependencyProperty.Register("ImageSource", typeof(string), typeof(IconButton), new PropertyMetadata(null));
            public string ImageSource
            {
                get { return (string)GetValue(ImageSourceProperty); }
                set { SetValue(ImageSourceProperty, value); }
            }
       }
  
