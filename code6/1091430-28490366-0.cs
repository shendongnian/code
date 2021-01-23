    class ObservableTransmittals : ObservableCollection<Transmittal>
    {
        private readonly YourContext _dataContext;
        public ObservableTransmittals(YourContext dataContext)
        {
            var linq = dataContext.Transmittals.OrderByDescending(x => x.TransName);
            foreach (Transmittal trn in linq)
            {
                this.Add(trn);
            }
            _dataContext = dataContext;
        }
        protected override void RemoveItem(int index)
        {
            _dataContext.Transmittals.Remove(this[index]);
            base.RemoveItem(index);
        }
        protected override void InsertItem(int index, Transmittal item)
        {
            _dataContext.Transmittals.Add(item);
            base.InsertItem(index, item);
        }
        protected override void SetItem(int index, Transmittal item)
        {
            // Add replace logic
            base.SetItem(index, item);
        }
    }
