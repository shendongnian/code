    void MyItemsSource_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
                foreach (SaleryDetailsModel item in e.NewItems)
                    item.PropertyChanged += MyType_PropertyChanged;
            if (e.OldItems != null)
                foreach (SaleryDetailsModel item in e.OldItems)
                    item.PropertyChanged -= MyType_PropertyChanged;
        }
    void MyType_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Amount")
                DoWork();
        }
        private void DoWork()
        {
            SalaryTotal = SaleryDetailsCollection.Sum(x => x.Amount);
        }
