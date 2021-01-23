     #region RelayCommand
        private RelayCommand<DragEventArgs> _dropUser;
        public RelayCommand<DragEventArgs> DropUser
        {
            get
            {
               return _dropUser ?? (_dropUser = new RelayCommand<DragEventArgs>(DropMethod,canExecute));
            }
        }
        private bool canExecute(DragEventArgs arg)
        {
            // check your condition return true . Command is only work when you return true.
        }
        #endregion
     // Method Will Fire here and do action here
     private void DropMethod(DragEventArgs eventArgs)
        {
            if (eventArgs != null)
            {
            }
        }  
