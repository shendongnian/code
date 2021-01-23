    public class FractalViewModel:PropertyChangedBase
    {
        private ObservableCollection<FractalCell> _cells;
        public int Rows { get; set; }
        public int Columns { get; set; }
        public ObservableCollection<FractalCell> Cells
        {
            get { return _cells; }
            set
            {
                _cells = value;
                OnPropertyChanged("Cells");
            }
        }
        public FractalViewModel()
        {
            var ctx = TaskScheduler.FromCurrentSynchronizationContext();
            Task.Factory.StartNew(() => CreateFractalCellsAsync())
                        .ContinueWith(x => Cells = new ObservableCollection<FractalCell>(x.Result), ctx);
        }
        private List<FractalCell> CreateFractalCellsAsync()
        {
            var cells = new List<FractalCell>();
            var colors = typeof(Colors).GetProperties().Select(x => (Color)x.GetValue(null, null)).ToList();
            var random = new Random();
            for (int i = 0; i < 32; i++)
            {
                for (int j = 0; j < 32; j++)
                {
                    cells.Add(new FractalCell() { Row = i, Column = j, Color = colors[random.Next(0, colors.Count)] });
                }
            }
            return cells;
        }
    }
