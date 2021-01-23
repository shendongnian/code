    using System;
    using Windows.Foundation;
    using Windows.Storage;
    using Windows.UI.Input;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Input;
    using Windows.UI.Xaml.Media;
    using Windows.UI.Xaml.Media.Imaging;
    namespace controlMagnifier
    {
        public sealed partial class MainPage : Page
        {
            public const int XAxis = 200;
            public const int YAxis = 435;
            private readonly RotateTransform myRotateTransform = new RotateTransform {CenterX = 0.5, CenterY = 1};
            private readonly ScaleTransform myScaleTransform = new ScaleTransform {ScaleX = 1, ScaleY = 1};
            private readonly TransformGroup myTransformGroup = new TransformGroup();
            private readonly TranslateTransform myTranslateTransform = new TranslateTransform();
            public WriteableBitmap CurrentBitmapObj, CurrentCroppedImage = null;
            public Point currentContactPt, GridPoint;
            public Thickness margin;
            public PointerPoint pt;
            public double xValue, yValue;
            public MainPage()
            {
                InitializeComponent();
                ParentGrid.Holding += Grid_Holding;
                image2.PointerMoved += InkCanvas_PointerMoved;
                image2.PointerReleased += ParentGrid_OnPointerReleased;
                margin = MagnifyTip.Margin;
                image2.CacheMode = new BitmapCache();
                myTransformGroup.Children.Add(myScaleTransform);
                myTransformGroup.Children.Add(myRotateTransform);
                myTransformGroup.Children.Add(myTranslateTransform);
                MagnifyTip.RenderTransformOrigin = new Point(0.5, 1);
                MagnifyTip.RenderTransform = myTransformGroup;
            }
            private void Grid_Holding(object sender, HoldingRoutedEventArgs e)
            {
                try
                {
                    GridPoint = e.GetPosition(image2);
                    myTranslateTransform.X = xValue - XAxis;
                    myTranslateTransform.Y = yValue - YAxis;
                    MagnifyTip.RenderTransform = myTransformGroup;
                    MagnifyTip.Visibility = Visibility.Visible;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            private void InkCanvas_PointerMoved(object sender, PointerRoutedEventArgs e)
            {
                try
                {
                    pt = e.GetCurrentPoint(image2);
                    currentContactPt = pt.Position;
                    xValue = currentContactPt.X;
                    yValue = currentContactPt.Y;
                    if (xValue > 300)
                    {
                        myRotateTransform.Angle = -90;
                    }
                    else if (xValue < 100)
                    {
                        myRotateTransform.Angle = 90;
                    }
                    else
                    {
                        myRotateTransform.Angle = 0;
                    }
                    MagnifyTip.RenderTransform = myRotateTransform;
                    myTranslateTransform.X = xValue - XAxis;
                    myTranslateTransform.Y = yValue - YAxis;
                    MagnifyTip.RenderTransform = myTransformGroup;
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    e.Handled = true;
                }
            }
            private async void StoreCrrentImage()
            {
                try
                {
                    var storageFile =
                        await
                            StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/wallpaper.jpg",
                                UriKind.RelativeOrAbsolute));
                    using (
                        var fileStream =
                            await storageFile.OpenAsync(FileAccessMode.Read))
                    {
                        var bitmapImage = new BitmapImage();
                        await bitmapImage.SetSourceAsync(fileStream);
                        var writeableBitmap =
                            new WriteableBitmap(bitmapImage.PixelWidth, bitmapImage.PixelHeight);
                        fileStream.Seek(0);
                        await writeableBitmap.SetSourceAsync(fileStream);
                        CurrentBitmapObj = writeableBitmap;
                        writeableBitmap.Invalidate();
                    }
                }
                catch (Exception)
                {
                    // Graphics g=new Graphics();
                    throw;
                }
                finally
                {
                }
            }
            private void ParentGrid_OnPointerReleased(object sender, PointerRoutedEventArgs e)
            {
                MagnifyTip.Visibility = Visibility.Collapsed;
            }
        }
    }
