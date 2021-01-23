    class BindableTypeThatSupportsBulkUpdate : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string _Text1;
        public string Text1
        {
            get { return _Text1; }
            set { _Text1 = value; NotifyPropertyChanged(); }
        }
        private string _Text2;
        public string Text2
        {
            get { return _Text2; }
            set { _Text2 = value; NotifyPropertyChanged(); }
        }
        private void NotifyPropertyChanged([CallerMemberName]string name = "")
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        public void BulkUpdate(string t1, string t2)
        {
            _Text1 = t1;
            _Text2 = t2;
            // Passing String.Empty as the name causes notification to fire for all the     properties
            NotifyPropertyChanged(String.Empty);
        }
    }
