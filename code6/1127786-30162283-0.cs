      if (dataContext is IMonitorable)
            {
                Context = dataContext as IMonitorable;
                Context.MonitorViewModel.RaiseMonitorItemAdd += MonitorViewModelOnRaiseMonitorItemAdd;
                Context.MonitorViewModel.RaiseMonitorCleared += MonitorViewModel_RaiseMonitorCleared;
            }
        private void MonitorViewModelOnRaiseMonitorItemAdd(object sender, MonitorEventArgs monitorEventArgs)
        {
            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() =>
            {
                _paragraph.Inlines.AddRange(MonitorItemConverter.ConvertToInlines(monitorEventArgs.MonitorItem));
                _richTextBox.ScrollToEnd();
            }));
        }
