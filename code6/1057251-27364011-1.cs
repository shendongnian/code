    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    
    namespace WpfApplication8
    {
        /// <summary>
        ///     Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
    
                IEnumerable<InkCanvasEditingMode> values =
                    Enum.GetValues(typeof (InkCanvasEditingMode)).Cast<InkCanvasEditingMode>();
                DataContext = values;
            }
    
            private void MainWindow_OnDrop(object sender, DragEventArgs e)
            {
                object data = e.Data.GetData(DataFormats.FileDrop);
                if (data != null)
                {
                    var strings = data as string[];
                    if (strings != null)
                    {
                        string s = strings[0];
    
                        var bitmapImage = new BitmapImage(new Uri(s));
                        var image = new Image
                        {
                            Stretch = Stretch.None,
                            Source = bitmapImage
                        };
                        InkCanvas1.Children.Add(image);
                    }
                }
            }
    
    
            private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                object addedItem = e.AddedItems[0];
    
                var inkCanvasEditingMode = (InkCanvasEditingMode) addedItem;
                InkCanvas1.EditingMode = inkCanvasEditingMode;
            }
        }
    }
