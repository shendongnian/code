    public static class ImageButton
    {
        
        /////////////////////// SourceNormal /////////////////////////////////////////////////////
        //----------------------------------------------------------------------------------------
        public static readonly DependencyProperty SourceNormalProperty = DependencyProperty.RegisterAttached(
            "SourceNormal",
            typeof(ImageSource),
            typeof(ImageButton),
            new PropertyMetadata(null)
        );
        public static ImageSource GetSourceNormal(UIElement element)
        {
            if (element == null)
            {
                new ArgumentNullException("element");
            }
            return (ImageSource)element.GetValue(SourceNormalProperty);
        }
        public static void SetSourceNormal(UIElement element, ImageSource value)
        {
            if (element == null)
            {
                new ArgumentNullException("element");
            }
            element.SetValue(SourceNormalProperty, value);
        }
        //----------------------------------------------------------------------------------------
        /////////////////////// SourcePressed ////////////////////////////////////////////////////
        //----------------------------------------------------------------------------------------
        public static readonly DependencyProperty SourcePressedProperty = DependencyProperty.RegisterAttached(
            "SourcePressed",
            typeof(ImageSource),
            typeof(ImageButton),
            new PropertyMetadata(null)
        );
        public static ImageSource GetSourcePressed(UIElement element)
        {
            if (element == null)
            {
                new ArgumentNullException("element");
            }
            return (ImageSource)element.GetValue(SourcePressedProperty);
        }
        public static void SetSourcePressed(UIElement element, ImageSource value)
        {
            if (element == null)
            {
                new ArgumentNullException("element");
            }
            element.SetValue(SourcePressedProperty, value);
        }
        //----------------------------------------------------------------------------------------
    }
