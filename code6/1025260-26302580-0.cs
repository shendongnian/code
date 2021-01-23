        private static readonly Action EmptyDelegate = delegate() { };
        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(name));
            }
            this.Dispatcher.Invoke(DispatcherPriority.Render, EmptyDelegate);
        }
