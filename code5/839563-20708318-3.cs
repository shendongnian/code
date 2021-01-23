    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    namespace ImageControl
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
            private void Image_MouseUp(object sender, MouseButtonEventArgs e)
            {
                Image image = sender as Image;
                // the above is an implicit cast, thus the reference will be null if it fails
                if (image == null)
                    return;
                ImageDialogue.ImageSource = image.Source;
                ImageDialogue.Visibility = Visibility.Visible;
            }
       }
    }
