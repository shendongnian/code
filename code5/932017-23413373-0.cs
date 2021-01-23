        private ICommand _DoSomething;
        public ICommand DoSomething
        {
            get
            {
                if (_DoSomething == null)
                {
                    _DoSomething = new RelayCommand(DoSomethingExecute);
                }
                return _DoSomething;
            }
        }
        private void DoSomethingExecute()
        {
            Dispatcher.BeginInvoke(() =>
                {
                    MessageBox.Show("btnTest on the tap event");
                });
        }
