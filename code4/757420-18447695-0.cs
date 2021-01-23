    public class DataGridSampleViewModel
    {
        public ObservableCollection<Step2Data> Data { get; set; }
        public ICommand AddItemCommand { get; set; }
        public DataGridSampleViewModel()
        {
            Data = new ObservableCollection<Step2Data>();
            AddItemCommand = new ActionCommand
            {
                ExecuteDelegate = o => Data.Add(new Step2Data { LayerName = DateTime.Now.Ticks.ToString() })
            };
        }
    }
