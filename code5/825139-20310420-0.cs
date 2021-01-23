    public class ImageButton : Button
    {
       public ImageSource ImageSource
       {
          get { return (ImageSource)GetValue(ImageSourceProperty); }
          set { SetValue(ImageSourceProperty, value); }
       }
    
       public static readonly DependencyProperty ImageSourceProperty =
                DependencyProperty.Register("ImageSource", typeof(ImageSource), 
                                              typeof(ImageButton));        
    }
