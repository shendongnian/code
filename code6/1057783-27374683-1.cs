     private RelayCommand<MouseButtonEventArgs> _selectElementCommand;
        public RelayCommand<MouseButtonEventArgs> SelectElementCommand
        {
            get
            {
                return _selectElementCommand
                    ?? (_selectElementCommand= new RelayCommand<MouseButtonEventArgs>(
                        (s) =>
                        {
                            var dep = s.OriginalSource as DependencyObject;
                            //go up the treeView until you find the ColumnHeader if existed 
                            while (dep != null && !(dep is DataGridColumnHeader))
                            {
                                dep = VisualTreeHelper.GetParent(dep);
                            }
                            if (!(dep is DataGridColumnHeader))
                                //you handler logic 
                        }));
            }
        }
