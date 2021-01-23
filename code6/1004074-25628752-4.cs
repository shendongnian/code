        public class ViewModel : INotifyPropertyChanged
    {
        public ViewModel()
        {
            LoadXaml();
        }
        FrameworkElement frameWorkElement;
        public FrameworkElement RuntimeFrameWorkElement
        {
            get { return frameWorkElement; }
            set { frameWorkElement = value; OnPropertyChanged("RuntimeFrameWorkElement"); }
        }
        public void LoadXaml()
        {
            FileInfo f = new FileInfo(@"F:\myxaml.txt"); //Load xaml from some external file
            if (f.Exists)
                using (var stream = f.OpenRead())
                {
                    this.RuntimeFrameWorkElement = XamlReader.Load(stream) as FrameworkElement;
                }
        }
        void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
