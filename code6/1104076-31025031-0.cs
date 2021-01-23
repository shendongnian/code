    public class PanAndZoomBehavior : Behavior<ScrollViewer>
        {
            protected override void OnAttached()
            {
                base.OnAttached();            
                Window.Current.SizeChanged += OnSizeChanged;
                SetElementSize();
                
            }
    
            protected override void OnDetaching()
            {
                base.OnDetaching();            
                Window.Current.SizeChanged -= OnSizeChanged;
            }
    
            private void OnSizeChanged(object sender, Windows.UI.Core.WindowSizeChangedEventArgs e)
            {
                SetElementSize();
            }
    
            private void SetElementSize()
            {
                AssociatedObject.Width = Window.Current.Bounds.Width;
                AssociatedObject.Height = Window.Current.Bounds.Height;
                if (AssociatedObject.Content != null)
                {
                    FrameworkElement element = (FrameworkElement)AssociatedObject.Content;
                    element.Width = Window.Current.Bounds.Width;
                    element.Height = Window.Current.Bounds.Height;
                }
            }
            
        }
