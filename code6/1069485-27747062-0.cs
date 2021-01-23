    public class Kind
    {
        public string Name { get; set; }
        public bool Active { get; set; }
        public int Value { get; set; }
    }
    public class AppEnumValues : INotifyPropertyChanged
    {
        private static readonly Lazy<AppEnumValues> current
            = new Lazy<AppEnumValues>(() => new AppEnumValues(), LazyThreadSafetyMode.ExecutionAndPublication);
        public static AppEnumValues Current
        {
            get { return current.Value; }
        }
        public Kind[] AllDifferentKinds { get; private set; }
        public bool IsLoaded { get; private set; }
        private AppEnumValues()
        {
            Task.Run(() => this.LoadEnumValuesFromDb())
                .ContinueWith(t => this.OnAllPropertiesChanged());
        }
        protected virtual void OnAllPropertiesChanged()
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(string.Empty));
            }
        }
        private void LoadEnumValuesFromDb()
        {
            // This simulates some latency
            Thread.Sleep(2000);
            // Call your data service here and load the values
            var kinds = new[]
                        {
                            new Kind {Active = true, Name = "WeeHee", Value = 1},
                            new Kind {Active = true, Name = "BuuHuu", Value = 2}
                        };
            this.AllDifferentKinds = kinds;
            this.IsLoaded = true;
        }
        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
    }
