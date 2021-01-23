    using System;
    using System.Diagnostics;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Input;
    using Windows.UI.Xaml.Media;
    using Windows.UI.Xaml.Media.Imaging;
    
    namespace App78
    {
        public sealed partial class MainPage : Page
        {
            private double zoomScale = 2;
            private double pointerX = 0;
            private double pointerY = 0;
            private const double MinZoomScale = .25;
            private const double MaxZoomScale = 32;
            
    
            public MainPage()
            {
                this.InitializeComponent();
               
                var bi = (BitmapImage)BigImage.Source;
                bi.ImageOpened += bi_ImageOpened;
                this.SizeChanged += MainPage_SizeChanged;
            }
    
            void MainPage_SizeChanged(object sender, Windows.UI.Xaml.SizeChangedEventArgs e)
            {
                this.UpdateImageLayout();
            }
    
            void bi_ImageOpened(object sender, Windows.UI.Xaml.RoutedEventArgs e)
            {
                this.UpdateImageLayout();
            }
    
            private void UpdateImageLayout()
            {
                var bi = (BitmapImage)BigImage.Source;
                if (bi.PixelWidth < this.LayoutGrid.ActualWidth &&
                    bi.PixelHeight < this.LayoutGrid.ActualHeight)
                {
                    this.BigImage.Stretch = Stretch.None;
                }
                else
                {
                    this.BigImage.Stretch = Stretch.Uniform;
                }
    
                this.UpdateMagnifier();
            }
    
            private void LayoutGrid_OnPointerMoved(object sender, PointerRoutedEventArgs e)
            {
                //DV: If pointer is not in contact we can ignore it
                if (!e.Pointer.IsInContact) { return; }
    
                var point = e.GetCurrentPoint(this.LayoutGrid);
                this.pointerX = point.Position.X;
                this.pointerY = point.Position.Y;
                this.UpdateMagnifier();
            }
    
            private void UpdateMagnifier()
            {
                var bi = (BitmapImage)BigImage.Source;
    
                double offsetX = 0;
                double offsetY = 0;
                double imageScale = 1;
               
                var imageRatio = (double)bi.PixelWidth / bi.PixelHeight;
                var gridRatio = this.LayoutGrid.ActualWidth / this.LayoutGrid.ActualHeight;
    
                if (bi.PixelWidth < this.LayoutGrid.ActualWidth &&
                    bi.PixelHeight < this.LayoutGrid.ActualHeight)
                {
                    offsetX = 0.5 * (this.LayoutGrid.ActualWidth - bi.PixelWidth);
                    offsetY = 0.5 * (this.LayoutGrid.ActualHeight - bi.PixelHeight);
                    //imageScale = 1; - remains
                }
                else if (imageRatio < gridRatio)
                {
                    offsetX = 0.5 * (this.LayoutGrid.ActualWidth - imageRatio * this.LayoutGrid.ActualHeight);
                    offsetY = 0;
                    imageScale = BigImage.ActualHeight / bi.PixelHeight;
                }
                else
                {
                    offsetX = 0;
                    offsetY = 0.5 * (this.LayoutGrid.ActualHeight - this.LayoutGrid.ActualWidth / imageRatio);
                    imageScale = BigImage.ActualWidth / bi.PixelWidth;
                }
    
                //DV: This is probably not need anymore
               //MagnifierTip.MagnifierTransform.X = this.pointerX;
               //MagnifierTip.MagnifierTransform.Y = this.pointerY;
                MagnifierTip.PositionTransform.X = (-this.pointerX + offsetX) / imageScale;
                MagnifierTip.PositionTransform.Y = (-this.pointerY + offsetY) / imageScale;
    
                //DV: I haven't tested the Scaling/Zoom
                MagnifierTip.ZoomTransform.ScaleX = imageScale * zoomScale;
                MagnifierTip.ZoomTransform.ScaleY = imageScale * zoomScale;
    
                MagnifierTip.CenterTransform.X = MagnifierTip.MagnifierEllipse.ActualWidth / 2 - MagnifierTip.MagnifierEllipse.StrokeThickness / 2;
                MagnifierTip.CenterTransform.Y = MagnifierTip.MagnifierEllipse.ActualHeight / 2 - MagnifierTip.MagnifierEllipse.StrokeThickness / 2;
    
                //DV: I added a GlobalGrid Transform which translates every children
                MagnifierTip.MagnifierTransformGrid.X = this.pointerX - (MagnifierTip.ActualWidth / 2);
                MagnifierTip.MagnifierTransformGrid.Y = this.pointerY - (MagnifierTip.ActualHeight); ;
    
            }
    
            private void LayoutGrid_OnPointerWheelChanged(object sender, PointerRoutedEventArgs e)
            {
                if (e.GetCurrentPoint(this.LayoutGrid).Properties.MouseWheelDelta > 0)
                {
                    zoomScale = Math.Max(MinZoomScale, Math.Min(MaxZoomScale, zoomScale * 1.2));
                }
                else
                {
                    zoomScale = Math.Max(MinZoomScale, Math.Min(MaxZoomScale, zoomScale / 1.2));
                }
    
                this.UpdateMagnifier();
            }
    
    
            //DV: Holding usually only works with touch https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.uielement.holding.aspx?f=255&MSPPError=-2147217396
            private void LayoutGrid_Holding(object sender, HoldingRoutedEventArgs e)
            {
                //
            }
    
            //DV: pointer pressed supports both mouse and touch but fires immeadiatley. You'll have to figure out a delay strategy or using holding for touch and right click for mouse
            private void LayoutGrid_OnPointerPressed(object sender, PointerRoutedEventArgs e)
            {
                MagnifierTip.Visibility = Windows.UI.Xaml.Visibility.Visible;
            }
    
            //DV: pointer released supports both mouse and touch.
            private void LayoutGrid_OnPointerReleased(object sender, PointerRoutedEventArgs e)
            {
                MagnifierTip.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            }
        }
    }
