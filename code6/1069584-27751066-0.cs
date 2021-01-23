    public class WeightsListViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<WeightViewModel> Weights
        {
            get;
            private set;
        }
        public WeightsListViewModel()
        {
            _context = new BenchMarkEntities();
            .Load();
            this.Weights = _context.Weights.Select(w => new WeightViewModel(w));
        }
    }
