         public class PlanModel : INotifyPropertyChanged
    {
        public PlanModel()
        {
        }
        public ObservableCollection<PlanData> Items { get; set; }
        public bool IsDataLoaded { get; set; }
        public void LoadData()
        {
            Items = new ObservableCollection<PlanData>();
            this.OnPropertyChanged("Items");
            LoadPlanData();
        }
        public void LoadPlanData()
        {
            // URL censored, the JSON is deserialized correctly, checked with debug
            Uri apiAddress = new Uri("http://example.com");
            // Web client is disposable, so wrap in a using statment to ensure clean up.
            WebClient client = new WebClient();
            client.DownloadStringCompleted += Client_DownloadStringCompleted;
            client.DownloadStringAsync(apiAddress);
        }
        void Client_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            string ApiResult;
            if (e.Error == null)
            {
                ApiResult = e.Result;
                var itemsFromService = JsonConvert.DeserializeObject<ObservableCollection<PlanData>>(ApiResult);
                foreach (var planDataItem in itemsFromService)
                {
                    this.Items.Add(planDataItem);
                }
                IsDataLoaded = true;
            }
        }
        // INotifyPropertyChanged implementation
        public void OnPropertyChanged(string propertyName)
        {
            var handler = this.PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
