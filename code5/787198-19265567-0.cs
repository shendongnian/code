    public class MyViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<string> _unprocessedData = new ObservableCollection<string>();
        private ObservableCollection<string> _processedData = new ObservableCollection<string>();
        private static object _lock = new object();
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<string> Collection { get { return _processedData; } }//Bind the view to this property
        public MyViewModel()
        {
            //Populate the data in _unprocessedData
            BindingOperations.EnableCollectionSynchronization(_processedData, _lock); //this will ensure the data between the View and VM is not corrupted
            ProcessData();
        }
        private async void ProcessData()
        {
            foreach (var item in _unprocessedData)
            {
                string result = await Task.Run(() => DoSomething(item));
                _processedData.Add(result);
                //NotifyPropertyChanged Collection
            }
        }
        private string DoSomething(string item)
        {
            Thread.Sleep(1000);
            return item;
        }
    }
