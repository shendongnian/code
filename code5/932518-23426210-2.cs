        private void LocalSearchCommandExecuted(object obj)
        {
            //can also be your loadingItem. 
            VisibleElement.Visibility = Visibility.Collapsed;
            //get the ui context
            var scheduler = TaskScheduler.FromCurrentSynchronizationContext();
            Task.Factory.StartNew(() =>
            {
                //do your query on the background thread
                LongRunningOperation();
            })
                      //this happens on the ui thread because of the second parameter scheduler 
                                   .ContinueWith(t =>
                                   {
                                       
                                       if (t.IsCompleted)
                                       {
                                           VisibleElement.Visibility = Visibility.Visible;
                                           //assign the result from the LongRunningOperation to your ui list
                                           _list = new List<string>(_tempList);
                                           //if you need to...
                                           RaisePropertyChanged("SearchResults");
                                       }
                                   }, scheduler );
        }
        private void LongRunningOperation()
        {
            //assign your result to a temporary collection
            //if you do not do that you will get an exception: An ItemsControl is inconsistent with its items source
            _tempList = new List<string>();
            for (int i = 0; i < 100; i++)
            {
                _tempList.Add("Test" + i);
                Thread.Sleep(10);
            }
        }
