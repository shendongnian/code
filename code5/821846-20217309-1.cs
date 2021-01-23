    using System.ComponentModel;
    using System.Windows;
    namespace WpfTestBench
    {
        public partial class PlayButton
        {
            public PlayButton()
            {
                InitializeComponent();
                DataContext = new SampleContext();
            }
            private void Button_OnClick(object sender, RoutedEventArgs e)
            {
                var context = DataContext as SampleContext;
                if (context == null)
                    return;
                context.IsPlaying = !context.IsPlaying;
            }
        }
        public class SampleContext : INotifyPropertyChanged
        {
            private bool _isPlaying;
            public bool IsPlaying
            {
                get { return _isPlaying; }
                set
                {
                    if (_isPlaying == value)
                        return;
                    _isPlaying = value;
                    OnPropertyChanged("IsPlaying");
                }
            }
            public event PropertyChangedEventHandler PropertyChanged;
            protected virtual void OnPropertyChanged(string propertyName)
            {
                var handler = PropertyChanged;
                if (handler != null)
                    handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
