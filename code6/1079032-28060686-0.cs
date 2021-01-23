    public class ContactsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        private IList data;
        public IList Data
        {
            get
            {
                if (data == null)
                {
                    // Ignore the returned Task...we're not going to do anything with it
                    var _ = InitData();
                }
                // Caller should handle null. If not, need to return "new Data[0]" here instead
                return data;
            }
        }
        private async Task InitData()
        {
            // Catch _specific_ exceptions here, if necessary
            var items = await ContactModel.CreateSampleData();
            data = items.ToAlphaGroups(x => x.Name);
            OnPropertyChanged("Data");
        }
        private CollectionViewSource collection;
        public CollectionViewSource Collection
        {
            get
            {
                if (collection == null)
                {
                    collection = new CollectionViewSource();
                    collection.Source = Data;
                    collection.IsSourceGrouped = true;
                }
                return collection;
            }
        }
    }
