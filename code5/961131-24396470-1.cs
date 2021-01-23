    class DataSourcePickerViewModel : IDataSourcePickerViewModel
    {
        public bool IsAccepted { get; set; }
        public ICommand NewDataSourceCommand { get; private set; }
        public DataSourcePickerViewModel()
        {
            NewDataSourceCommand = new RelayCommand(() =>
            {
                IsAccepted = true;
            });
        }
    }
