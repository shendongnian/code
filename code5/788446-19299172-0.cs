    public class MyAttached
    {
        public static readonly DependencyProperty GeometryOpacityMaskProperty =
            DependencyProperty.RegisterAttached("GeometryOpacityMask", typeof(Path), typeof(MyAttached), new PropertyMetadata(default(Path), GeometryOpacityMaskChanged));
        private static void GeometryOpacityMaskChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            FrameworkElement uiElement = d as FrameworkElement;
            Path path = e.NewValue as Path;
            if (path != null && uiElement != null)
            {
                WriteableBitmap writeableBitmap = new WriteableBitmap((int)uiElement.Width, (int)uiElement.Height);
                writeableBitmap.Render(path, new CompositeTransform());
                writeableBitmap.Invalidate();
                ImageBrush imageBrush=new ImageBrush();
                imageBrush.ImageSource = writeableBitmap;
                uiElement.OpacityMask = imageBrush;
            }
        }
        public static void SetGeometryOpacityMask(UIElement element, Path value)
        {
            element.SetValue(GeometryOpacityMaskProperty, value);
        }
        public static Path GetGeometryOpacityMask(UIElement element)
        {
            return (Path)element.GetValue(GeometryOpacityMaskProperty);
        }
    }
