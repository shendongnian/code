    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    
    namespace UIToBitmap
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
    
                this.Loaded += MainWindow_Loaded;
            }
    
            void MainWindow_Loaded(object sender, RoutedEventArgs e)
            {
                var source = ConvertToBitmapSource(circle);
                Image.Source = source;
            }
    
            public BitmapSource ConvertToBitmapSource(UIElement element)
            {
                var target = new RenderTargetBitmap((int)(element.RenderSize.Width), (int)(element.RenderSize.Height), 96, 96, PixelFormats.Pbgra32);
                var brush = new VisualBrush(element);
    
                var visual = new DrawingVisual();
                var drawingContext = visual.RenderOpen();
    
    
                drawingContext.DrawRectangle(brush, null, new Rect(new Point(0, 0),
                    new Point(element.RenderSize.Width, element.RenderSize.Height)));
    
                drawingContext.PushOpacityMask(brush);
    
                drawingContext.Close();
    
                target.Render(visual);
    
                return target;
            } 
        }
    }
