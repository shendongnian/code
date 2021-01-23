    internal sealed class MainViewModel
    {
        private readonly IEnumerable<ResultData> items = new[]
            {
                new ResultData("Report 00"),
                new ResultData("Report 01"),
                new ResultData("Report 02"),
                new ResultData(null)
            };
        private readonly ICommand openPiWebCommand;
        public MainViewModel()
        {
            openPiWebCommand = new RelayCommand<ResultData>(
                OpenPiWeb,
                x => x != null && x.PiWebReport != null);
        }
        public IEnumerable<ResultData> Items
        {
            get { return items; }
        }
        public ICommand OpenPiWebCommand
        {
            get { return openPiWebCommand; }
        }
        private void OpenPiWeb(ResultData data)
        {
            // Implement the command logic.
        }
    }
