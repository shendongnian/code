    public class YourViewModel : INotifyPropertyChanged
    {
        private string _searchString;
        private string _imageSource;
        public string SearchString
        {
            get { return _searchString; }
            set
            {
                if (value == _searchString) return;
                _searchString = value;
                OnPropertyChanged();
                ImageSource = @"/FunctionWizardControl;component/Images/Search_next.ico";
            }
        }
        public string ImageSource
        {
            get { return _imageSource; }
            set
            {
                // Only change image, if different than before
                if (value == _imageSource) return;
                _imageSource = value;
                OnPropertyChanged();
            }
        }
        // Implement INotifyPropertyChanged with method 'OnPropertyChanged'...
    }
