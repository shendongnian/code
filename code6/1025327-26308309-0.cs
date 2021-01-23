    using System;
    using System.IO;
    using System.Windows;
    using System.Windows.Controls;
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
                DynamicImage1.SetSource(@"d:\Untitled.png");
            }
        }
    
        internal class DynamicImage : Image
        {
            private string _name;
            private FileSystemWatcher _watcher;
    
            public void SetSource(string fileName)
            {
                if (fileName == null) throw new ArgumentNullException("fileName");
    
                if (_watcher != null)
                {
                    _watcher.Changed -= watcher_Changed;
                    _watcher.Dispose();
                }
                string path = Path.GetDirectoryName(fileName);
                _watcher = new FileSystemWatcher(path);
                _watcher.EnableRaisingEvents = true;
                _watcher.Changed += watcher_Changed;
                _name = fileName;
                string tempFileName = Path.GetTempFileName();
                File.Copy(fileName, tempFileName, true);
                Source = new BitmapImage(new Uri(tempFileName));
            }
    
            private void watcher_Changed(object sender, FileSystemEventArgs e)
            {
                bool b = string.Equals(e.FullPath, _name, StringComparison.InvariantCultureIgnoreCase);
                if (b)
                {
                    string tempFileName = Path.GetTempFileName();
                    File.Copy(e.FullPath, tempFileName, true);
    
                    Dispatcher.BeginInvoke((Action) (() => { Source = new BitmapImage(new Uri(tempFileName)); }));
                    _name = e.FullPath;
                }
            }
        }
    }
