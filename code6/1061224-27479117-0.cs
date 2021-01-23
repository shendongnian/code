    public FooViewModel()
        {
            this.OCollection += this.OCollectionChanged;
        }
        private void OCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            var collection = sender as System.Collections.Generic.List<Bar>;
            if (collection != null && collection.Count > 1)
            {
                this.IsButtonVisible = true;
                base.RaisePropertyChanged(() => this.IsButtonVisible);
            }
        }
