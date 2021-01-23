        #region UncheckedItems
        private ObservableCollection<ItemViewModel> _UncheckedItems;
        public ObservableCollection<ItemViewModel> UncheckedItems
        {
            get { return _UncheckedItems ?? (_UncheckedItems = GetAllUncheckedItems()); }
        }
        private ObservableCollection<ItemViewModel> GetAllUncheckedItems()
        {
            var toRet = new ObservableCollection<ItemViewModel>();
            foreach (var i in Enumerable.Range(1,10))
            {
                toRet.Add(new ItemViewModel {Name = string.Format("Name-{0}", i), IsChecked = false});
            }
            return toRet;
        }        
        #endregion
        #region CheckedItems
        private ObservableCollection<ItemViewModel> _CheckedItems;
        public ObservableCollection<ItemViewModel> CheckedItems
        {
            get { return _CheckedItems ?? (_CheckedItems = GetAllCheckedItems()); }
        }
        private ObservableCollection<ItemViewModel> GetAllCheckedItems()
        {
            var toRet = new ObservableCollection<ItemViewModel>();
            foreach (var i in Enumerable.Range(11, 20))
            {
                toRet.Add(new ItemViewModel { Name = string.Format("Name-{0}", i), IsChecked = true });
            }
            return toRet;
        }
        #endregion
