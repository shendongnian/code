        #region CheckItem
        private RelayCommand<ItemViewModel> _CheckItemCommand;
        public RelayCommand<ItemViewModel> CheckItemCommand
        {
            get { return _CheckItemCommand ?? (_CheckItemCommand = new RelayCommand<ItemViewModel>(ExecuteCheckItemCommand, CanExecuteCheckItemCommand)); }
        }
        private void ExecuteCheckItemCommand(ItemViewModel item)
        {
            //ComandCode
            item.IsChecked = true;
            UncheckedItems.Remove(item);
            CheckedItems.Add(item);
        }
        private bool CanExecuteCheckItemCommand(ItemViewModel item)
        {
            return true;
        }
        #endregion
