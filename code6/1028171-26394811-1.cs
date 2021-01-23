    using System;
    using System.Timers;
    using System.Windows;
    
    namespace WpfApplication4
    {
        public partial class MainWindow
        {
            private int _length;
            private string _text;
    
            public MainWindow() {
                InitializeComponent();
                Loaded += MainWindow_Loaded;
            }
    
            private void MainWindow_Loaded(object sender, RoutedEventArgs e) {
                _text = "Hello, world !";
                var timer = new Timer(100);
                timer.Elapsed += timer_Elapsed;
                timer.Start();
            }
    
            private void timer_Elapsed(object sender, ElapsedEventArgs e) {
                _length++;
                if (_length > _text.Length) _length = 0;
                var substring = _text.Substring(0, _length);
                Dispatcher.BeginInvoke((Action) (() => { TextBlock1.Text = substring; }));
            }
        }
    }
