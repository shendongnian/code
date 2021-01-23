    using System;
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    
    namespace WpfApplication4
    {
        /// <summary>
        ///     Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                Loaded += MainWindow_Loaded;
            }
    
            private void MainWindow_Loaded(object sender, RoutedEventArgs e)
            {
                var image1 = new BitmapImage(new Uri("1.png", UriKind.Relative));
                var image2 = new BitmapImage(new Uri("2.png", UriKind.Relative));
                var bitmap1 = BitmapFactory.ConvertToPbgra32Format(image1);
                var bitmap2 = BitmapFactory.ConvertToPbgra32Format(image2);
    
                var width = 256;
                var height = 256;
                var bitmap3 = BitmapFactory.New(width, height);
    
                var transparent = Color.FromArgb(0, 0, 0, 0);
                for (var y = 0; y < height; y++)
                {
                    for (var x = 0; x < width; x++)
                    {
                        var color1 = bitmap1.GetPixel(x, y);
                        var color2 = bitmap2.GetPixel(x, y);
                        Color color3;
                        if (color1.Equals(transparent))
                        {
                            color3 = transparent;
                        }
                        else
                        {
                            if (color2.Equals(transparent))
                            {
                                color3 = color1;
                            }
                            else
                            {
                                color3 = transparent;
                            }
                        }
                        bitmap3.SetPixel(x, y, color3);
                    }
                }
                Image1.Source = bitmap3;
            }
        }
    }
