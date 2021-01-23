    using System;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Input;
    using Windows.UI.Xaml.Media;
    using Windows.UI.Xaml.Media.Imaging;
    
    namespace MagnifierApp
    {
        public sealed partial class MainPage : Page
        {
            private double zoomScale = 2;
            private double pointerX = 0;
            private double pointerY = 0;
            private const double MinZoomScale = .25;
            private const double MaxZoomScale = 32;
            private bool isFirst = true;
            
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
                if (!e.Pointer.IsInContact)
                {
                    return;
                }
    
                var point = e.GetCurrentPoint(this.LayoutGrid);
                this.pointerX = point.Position.X;
                this.pointerY = point.Position.Y;
                this.UpdateMagnifier();
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
    
            private void LayoutGrid_OnPointerPressed(object sender, PointerRoutedEventArgs e)
            {
                if (!e.Pointer.IsInContact) { return; }
                
                var point = e.GetCurrentPoint(this.LayoutGrid);
    
                this.pointerX = point.Position.X;
                this.pointerY = point.Position.Y;
                this.UpdateMagnifier();
                MagnifierTip.Visibility = Windows.UI.Xaml.Visibility.Visible;
            }
    
            private void LayoutGrid_OnPointerReleased(object sender, PointerRoutedEventArgs e)
            {
                MagnifierTip.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            }
    
            private void UpdateMagnifier()
            {
                var bi = (BitmapImage)BigImage.Source;
    
                double offsetX;
                double offsetY;
                double imageScale;
                CalculateImageScaleAndOffsets(bi, out offsetX, out offsetY, out imageScale);
    
                MagnifierTip.PositionTransform.X = (-this.pointerX + offsetX) / imageScale;
                MagnifierTip.PositionTransform.Y = (-this.pointerY + offsetY) / imageScale;
                MagnifierTip.ZoomTransform.ScaleX = imageScale * zoomScale;
                MagnifierTip.ZoomTransform.ScaleY = imageScale * zoomScale;
    
                MagnifierTip.CenterTransform.X = MagnifierTip.MagnifierEllipse.ActualWidth / 2 - MagnifierTip.MagnifierEllipse.StrokeThickness / 2;
                MagnifierTip.CenterTransform.Y = MagnifierTip.MagnifierEllipse.ActualHeight / 2 - MagnifierTip.MagnifierEllipse.StrokeThickness / 2;
    
                MagnifierTip.MagnifierTranslateTransform.X = this.pointerX - (MagnifierTip.ActualWidth / 2);
                MagnifierTip.MagnifierTranslateTransform.Y = this.pointerY - (MagnifierTip.ActualHeight);
    
                bool tooHigh = MagnifierTip.MagnifierTranslateTransform.Y < 0;
                bool tooLeft = MagnifierTip.MagnifierTranslateTransform.X < 0;
                bool tooRight = MagnifierTip.MagnifierTranslateTransform.X + MagnifierTip.ActualWidth > this.LayoutGrid.ActualWidth;
    
                if (tooHigh || tooLeft || tooRight)
                {
                    double angle = 0.0;
    
                    if (tooLeft && !tooHigh)
                    {
                        var dx = -MagnifierTip.MagnifierTranslateTransform.X;
                        var r = MagnifierTip.ActualHeight - MagnifierTip.ActualWidth / 2;
                        var arad = Math.Asin(dx / r);
                        angle = arad * 180 / Math.PI;
                    }
                    else if (tooLeft && tooHigh)
                    {
                        var dx = -MagnifierTip.MagnifierTranslateTransform.X;
                        var dy = -MagnifierTip.MagnifierTranslateTransform.Y;
                        var r = MagnifierTip.ActualHeight - MagnifierTip.ActualWidth / 2;
                        var arad1 = Math.Asin(dx / r);
                        var arad2 = Math.Acos((r - dy) / r);
                        var arad = Math.Max(arad1, arad2);
                        angle = arad * 180 / Math.PI;
                    }
                    else if (tooHigh && !tooRight)
                    {
                        var dy = -MagnifierTip.MagnifierTranslateTransform.Y;
                        var r = MagnifierTip.ActualHeight - MagnifierTip.ActualWidth / 2;
                        var arad = Math.Acos((r - dy) / r);
    
                        if (MagnifierTip.MagnifierTranslateTransform.X + Math.Sin(arad) * r + MagnifierTip.ActualWidth > this.LayoutGrid.ActualWidth)
                        {
                            arad = -arad;
                        }
    
                        angle = arad * 180 / Math.PI;
                    }
                    else if (tooHigh)
                    {
                        var dy = -MagnifierTip.MagnifierTranslateTransform.Y;
                        var dx = MagnifierTip.MagnifierTranslateTransform.X + MagnifierTip.ActualWidth - this.LayoutGrid.ActualWidth;
                        var r = MagnifierTip.ActualHeight - MagnifierTip.ActualWidth / 2;
                        var arad1 = -Math.Acos((r - dy) / r);
                        var arad2 = -Math.Asin(dx / r);
                        var arad = Math.Min(arad1, arad2);
                        angle = arad * 180 / Math.PI;
                    }
                    else //if (tooRight)
                    {
                        var dx = MagnifierTip.MagnifierTranslateTransform.X + MagnifierTip.ActualWidth - this.LayoutGrid.ActualWidth;
                        var r = MagnifierTip.ActualHeight - MagnifierTip.ActualWidth / 2;
                        var arad = -Math.Asin(dx / r);
                        angle = arad * 180 / Math.PI;
                    }
    
                    MagnifierTip.RotateTransform.Angle = angle;
                    MagnifierTip.LensRotateTransform.Angle = -angle;
                }
                else
                {
                    MagnifierTip.RotateTransform.Angle = 0;
                    MagnifierTip.LensRotateTransform.Angle = 0;
                }
            }
    
            private void CalculateImageScaleAndOffsets(BitmapImage bi, out double offsetX, out double offsetY, out double imageScale)
            {
                var imageRatio = (double)bi.PixelWidth / bi.PixelHeight;
                var gridRatio = this.LayoutGrid.ActualWidth / this.LayoutGrid.ActualHeight;
    
                if (bi.PixelWidth < this.LayoutGrid.ActualWidth &&
                    bi.PixelHeight < this.LayoutGrid.ActualHeight)
                {
                    offsetX = 0.5 * (this.LayoutGrid.ActualWidth - bi.PixelWidth);
                    offsetY = 0.5 * (this.LayoutGrid.ActualHeight - bi.PixelHeight);
                    imageScale = 1;
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
            }
        }
    }
