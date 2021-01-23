    using System;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Media;
    
    namespace Controls
    {
        public class ImageInScrollView : DependencyObject
        {
            public static readonly DependencyProperty HandlerEnabledProperty =
                DependencyProperty.RegisterAttached("HandlerEnabled", typeof(bool), typeof(Image), new PropertyMetadata(false, OnHandlerEnabledChanged));
            public static void SetHandlerEnabled(DependencyObject obj, object value)
            {
                obj.SetValue(HandlerEnabledProperty, value);
            }
            public static object GetHandlerEnabled(DependencyObject obj)
            {
                return obj.GetValue(HandlerEnabledProperty);
            }
            private static void OnHandlerEnabledChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                Image image = (d as Image);
                bool HandlerEnabled;
                bool.TryParse(e.NewValue.ToString(), out HandlerEnabled);
                if (HandlerEnabled)
                {
                    image.ImageOpened -= ImageOpenedInScrollViewer;
                    image.ImageOpened += ImageOpenedInScrollViewer;
                    image.Stretch = Stretch.None;
                }
                else
                {
                    image.ImageOpened -= ImageOpenedInScrollViewer;
                }
            }
    
            private static void ImageOpenedInScrollViewer(object sender, Windows.UI.Xaml.RoutedEventArgs e)
            {
                Image image = sender as Image;
    
                ScrollViewer parentScrollView = GetParentScrollView(image.Parent as FrameworkElement);
                if(parentScrollView == null)
                    return;
    
                parentScrollView.IsScrollInertiaEnabled = true;
                parentScrollView.SizeChanged -= ParentScrollView_SizeChanged;
                parentScrollView.SizeChanged += ParentScrollView_SizeChanged;
    
                ImageUpdateHandler(image, parentScrollView);
            }
    
            private static void ImageUpdateHandler(Image image, ScrollViewer scrollView)
            {
                if(image == null || scrollView == null)
                    return;
    
                if (image.ActualWidth < 0.001 || image.ActualHeight < 0.001)
                {
                    image.SizeChanged += image_SizeChanged;
                    return;
                }
    
                image.Width = image.ActualWidth;
                image.Height = image.ActualHeight;
    
                float minZoomFactor = (float)Math.Min(
                        scrollView.ViewportWidth / image.ActualWidth,
                        scrollView.ViewportHeight / image.ActualHeight);
                if (Math.Abs(scrollView.MinZoomFactor - minZoomFactor) < 0.001)
                    return;
    
                scrollView.MinZoomFactor = minZoomFactor;
                scrollView.ChangeView(null, null, scrollView.MinZoomFactor, true);
            }
    
            static void image_SizeChanged(object sender, SizeChangedEventArgs e)
            {
                var image = sender as Image;
                image.SizeChanged -= image_SizeChanged;
                ScrollViewer parentScrollView = GetParentScrollView(image.Parent as FrameworkElement);
                if (parentScrollView == null)
                    return;
    
                ImageUpdateHandler(image, parentScrollView);
            }
    
            static void ParentScrollView_SizeChanged(object sender, SizeChangedEventArgs e)
            {
                var scrollView = sender as ScrollViewer;
                var image = Helper.FindFirstChild<Image>(scrollView);
                ImageUpdateHandler(image, scrollView);
            }
    
            private static ScrollViewer GetParentScrollView(FrameworkElement parent)
            {
                ScrollViewer parentScrollView;
                while ((parentScrollView = parent as ScrollViewer) == null)
                {
                    parent = parent.Parent as FrameworkElement;
                    if (parent == null)
                        return null;
                }
                return parentScrollView;
            }
        }
    }
        
