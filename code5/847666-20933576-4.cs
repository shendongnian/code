    class SomeViewModel
    {
        IEnumerable<Results> Results { get; set; } // Obviously this would actually need to raise PropertyChanged from INotifyPropertyChanged in order to refresh any bindings
        
        public SomeViewModel()
        {
            var period = TimeSpan.FromMinutes(1);
            var timer = ThreadPoolTimer.CreatePeriodicTimer((source) =>
            {
                 // do your query/work here
                 DoSomeWorkAsync();
            }, 
            period);
        }
        void DoSomeWorkAsync()
        {
            // Get the data
            someService.GetResults((result) => { Results = result.Data; });
        }
    }
