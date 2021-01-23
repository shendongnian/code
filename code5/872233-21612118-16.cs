    using System;
    using System.Windows;
    using System.Windows.Media.Imaging;
    
    namespace WpfApplication1
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
    
                LoadSourceImages();
            }
    
            private void LoadSourceImages()
            {
                animation._Image1 = new BitmapImage(new Uri(@"pictures\image1.jpg"));
                animation._Image2 = new BitmapImage(new Uri(@"pictures\image2.jpg"));
                animation.Initiate();
            }
        }
    }
