    public class ChartDenominationViewModel : ViewModel
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                NotifyPropertyChanged("Title");
            }
        }
        private ObservableCollection<LineSeries> _lines = new ObservableCollection<LineSeries>();
        public ObservableCollection<LineSeries> Lines
        {
            get { return _lines; }
            set
            {
                _lines = value;
                NotifyPropertyChanged("Lines");
            }
        }
    }
